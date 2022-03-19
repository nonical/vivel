using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Vivel.Database;
using Vivel.Extensions;
using Vivel.Helpers;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Pagination;
using Vivel.Model.Requests.Donation;
using Vivel.Model.Requests.Drive;

namespace Vivel.Services
{
    public class DriveService : BaseCRUDService<DriveDTO, Drive, DriveSearchRequest, DriveInsertRequest, DriveUpdateRequest>, IDriveService
    {
        private readonly INotificationService _notificationService;

        public DriveService(VivelContext context, IMapper mapper, INotificationService notificationService) : base(context, mapper)
        {
            _notificationService = notificationService;
        }

        public async override Task<PagedResult<DriveDTO>> Get(DriveSearchRequest request = null)
        {
            var entity = _context.Set<Drive>()
                .Include(x => x.Status)
                .Include(x => x.BloodType)
                .Include(x => x.Hospital)
                .AsQueryable();

            if (request?.FromDate != null)
            {
                entity = entity.Where(x => x.Date >= request.FromDate);
            }

            if (request?.ToDate != null)
            {
                entity = entity.Where(x => x.Date <= request.ToDate);
            }

            if (request?.BloodType?.Count > 0)
            {
                entity = entity.Where(drive => request.BloodType.Any(x => x == drive.BloodType.Name));
            }

            if (request?.Amount != null)
            {
                entity = entity.Where(x => x.Amount == request.Amount);
            }

            if (request?.Status?.Count > 0)
            {
                entity = entity.Where(drive => request.Status.Contains(drive.Status.Name));
            }

            entity = entity.OrderByDescending(drive => drive.Urgency);

            if (request.Latitude != null && request.Longitude != null)
            {
                var location = GeographyHelper.CreatePoint(request.Longitude, request.Latitude);

                entity = entity
                    .Where(drive => drive.Hospital.Location.Distance(location) <= 30000)
                    .OrderByDescending(drive => drive.Urgency)
                    .ThenBy(drive => drive.Hospital.Location.Distance(location));
            }

            return await entity.GetPagedAsync<Drive, DriveDTO>(_mapper, request.Page, request.PageSize, request.Paginate);
        }

        public async override Task<DriveDTO> GetById(string id)
        {
            var entity = await _context.Drives
                .Include(x => x.Status)
                .Include(x => x.Hospital)
                .Include(x => x.BloodType)
                .Where(x => x.DriveId == id)
                .FirstOrDefaultAsync();

            return _mapper.Map<DriveDTO>(entity);
        }

        public async override Task<DriveDTO> Insert(DriveInsertRequest request)
        {
            var entity = _mapper.Map<Drive>(request);

            entity.Status = await _context.DriveStatuses.FirstAsync(x => x.Name == "Open");
            entity.BloodType = await _context.BloodTypes.Where(x => x.Name == request.BloodType).FirstAsync();

            await _context.AddAsync(entity);

            await _context.SaveChangesAsync();

            _context.Entry(entity).Reference(x => x.Hospital).Load();


            var userIds = await _context.Users
                                  .Where(x => x.BloodType == entity.BloodType && entity.Hospital.Location.Distance(x.Location) <= 30000)
                                  .Select(x => x.UserId)
                                  .ToListAsync();


            await NotifyUsers(userIds, entity);

            return _mapper.Map<DriveDTO>(entity);
        }

        public async Task NotifyUsers(List<string> userIds, Drive drive)
        {
            var title = drive.Urgency ? "Urgent drive in your area" : "New drive in your area";

            await _notificationService.PostNotifications<Drive>(userIds, drive.DriveId, title, "A drive just opened for your blood type!");
        }

        public async override Task<DriveDTO> Update(string id, DriveUpdateRequest request)
        {
            using var connection = _context.Database.GetDbConnection();
            await connection.OpenAsync();

            using var transaction = await connection.BeginTransactionAsync();
            _context.Database.UseTransaction(transaction);

            var entity = await _context.Drives.FindAsync(id);
            _mapper.Map(request, entity);

            entity.Status = await _context.DriveStatuses.Where(x => x.Name == request.Status).FirstAsync();
            entity.BloodType = await _context.BloodTypes.Where(x => x.Name == request.BloodType).FirstAsync();

            await _context.SaveChangesAsync();

            if (request.Status == "Closed")
            {
                var sqlUpdateDonations = @"UPDATE Donations
                                           SET StatusDonationStatusId = @rejectedId, UpdatedAt = GETDATE()
                                           WHERE DriveId = @driveId AND StatusDonationStatusId IN (@pendingId, @scheduledId)";

                var sqlUpdateDonationReports = @"UPDATE DonationReports
                                                 SET Note = @note, UpdatedAt = GETDATE()
                                                 WHERE DonationId IN (SELECT DonationId
                                                                      FROM Donations
                                                                      WHERE DriveId = @driveId AND StatusDonationStatusId = @rejectedId AND Note IS NULL)";

                var rejectedStatusId = await _context.DonationStatuses.Where(x => x.Name == "Rejected").Select(x => x.DonationStatusId).FirstAsync();
                var pendingStatusId = await _context.DonationStatuses.Where(x => x.Name == "Pending").Select(x => x.DonationStatusId).FirstAsync();
                var scheduledStatusId = await _context.DonationStatuses.Where(x => x.Name == "Scheduled").Select(x => x.DonationStatusId).FirstAsync();

                var commandDonations = connection.CreateCommand();
                var commandDonationReports = connection.CreateCommand();

                commandDonations.Transaction = transaction;
                commandDonations.CommandText = sqlUpdateDonations;
                commandDonations.Parameters.Add(new SqlParameter("@rejectedId", rejectedStatusId));
                commandDonations.Parameters.Add(new SqlParameter("@driveId", id));
                commandDonations.Parameters.Add(new SqlParameter("@pendingId", pendingStatusId));
                commandDonations.Parameters.Add(new SqlParameter("@scheduledId", scheduledStatusId));

                commandDonationReports.Transaction = transaction;
                commandDonationReports.CommandText = sqlUpdateDonationReports;
                commandDonationReports.Parameters.Add(new SqlParameter("@note", "Drive has been closed by the hospital"));
                commandDonationReports.Parameters.Add(new SqlParameter("@driveId", id));
                commandDonationReports.Parameters.Add(new SqlParameter("@rejectedId", rejectedStatusId));

                await commandDonations.ExecuteNonQueryAsync();
                await commandDonationReports.ExecuteNonQueryAsync();
            }

            transaction.Commit();

            return _mapper.Map<DriveDTO>(entity);
        }

        public async Task<PagedResult<DonationDTO>> Donations(string id, DonationSearchRequest request)
        {
            var entity = _context.Donations
                .Include(x => x.DonationReport)
                .Include(x => x.Status)
                .Include(x => x.Drive).ThenInclude(x => x.BloodType)
                .Include(x => x.Drive).ThenInclude(x => x.Hospital)
                .Include(x => x.User)
                .Where(x => x.DriveId == id)
                .AsQueryable();

            if (request?.ScheduledAt != null)
            {
                entity = entity.Where(x => x.ScheduledAt.Value.Date == request.ScheduledAt.Value.Date);
            }

            if (request?.Status?.Count > 0)
            {
                entity = entity.Where(donation => request.Status.Any(x => x == donation.Status.Name));
            }

            return await entity.GetPagedAsync<Donation, DonationDTO>(_mapper, request.Page, request.PageSize, request.Paginate);
        }

        public async Task<DriveDetailsDTO> Details(string id)
        {
            var entity = await _context.Drives
                .Include(x => x.BloodType)
                .Include(x => x.Hospital)
                .Include(x => x.Donations).ThenInclude(x => x.Status)
                .Where(x => x.DriveId == id)
                .FirstOrDefaultAsync();

            return _mapper.Map<DriveDetailsDTO>(entity);
        }

    }
}
