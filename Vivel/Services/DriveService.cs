using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using Vivel.Database;
using Vivel.Extensions;
using Vivel.Helpers;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Enums;
using Vivel.Model.Pagination;
using Vivel.Model.Requests.Donation;
using Vivel.Model.Requests.Drive;

namespace Vivel.Services
{
    public class DriveService : BaseCRUDService<DriveDTO, Drive, DriveSearchRequest, DriveInsertRequest, DriveUpdateRequest>, IDriveService
    {
        public DriveService(VivelContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async override Task<PagedResult<DriveDTO>> Get(DriveSearchRequest request = null)
        {
            var entity = _context.Set<Drive>().Include(x => x.Hospital).AsQueryable();

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
                entity = entity.Where(drive => request.BloodType.Select(x => BloodType.FromName(x, false)).Any(z => z == drive.BloodType));
            }

            if (request?.Amount != null)
            {
                entity = entity.Where(x => x.Amount == request.Amount);
            }

            if (request?.Status?.Count > 0)
            {
                entity = entity.Where(drive => request.Status.Select(x => DriveStatus.FromName(x, false)).Any(y => y == drive.Status));
            }

            entity = entity.OrderByDescending(drive => drive.Urgency);

            if (request.Latitude != null && request.Longitude != null)
            {
                var location = GeographyHelper.CreatePoint(request.Longitude, request.Latitude);

                entity = entity.Where(drive => drive.Hospital.Location.Distance(location) <= 30000)
                    .OrderByDescending(drive => drive.Urgency)
                    .ThenBy(drive => drive.Hospital.Location.Distance(location));
            }


            return await entity.GetPagedAsync<Drive, DriveDTO>(_mapper, request.Page, request.PageSize, request.Paginate);
        }

        public async override Task<DriveDTO> GetById(string id)
        {
            var entity = await _context.Drives.Include(x => x.Hospital).FirstOrDefaultAsync(x => x.DriveId == id);

            return _mapper.Map<DriveDTO>(entity);
        }

        public async override Task<DriveDTO> Update(string id, DriveUpdateRequest request)
        {
            using var connection = _context.Database.GetDbConnection();
            await connection.OpenAsync();

            using var transaction = await connection.BeginTransactionAsync();
            _context.Database.UseTransaction(transaction);

            var entity = await _context.Drives.FindAsync(id);
            _mapper.Map(request, entity);
            await _context.SaveChangesAsync();

            if (request.Status == DriveStatus.Closed.Name)
            {
                var rawSql = @"UPDATE Donation
                               SET Status = 'Rejected', Note = @Note
                               WHERE DriveID = @DriveID AND (Status = 'Pending' OR Status = 'Scheduled')";

                var driveId = new SqlParameter("@DriveID", id);
                var note = new SqlParameter("@Note", "Drive has been closed by the hospital");

                var command = connection.CreateCommand();
                command.Transaction = transaction;
                command.CommandText = rawSql;
                command.Parameters.Add(driveId);
                command.Parameters.Add(note);

                await command.ExecuteNonQueryAsync();
            }

            transaction.Commit();

            return _mapper.Map<DriveDTO>(entity);
        }

        public async Task<PagedResult<DonationDTO>> Donations(string id, DonationSearchRequest request)
        {
            var entity = _context.Donations.Where(x => x.DriveId == id).Include(x => x.User).AsQueryable();

            if (request?.ScheduledAt != null)
            {
                entity = entity.Where(x => x.ScheduledAt.Value.Date == request.ScheduledAt.Value.Date);
            }

            if (request?.Status?.Count > 0)
            {
                entity = entity.Where(donation => request.Status.Select(x => DonationStatus.FromName(x, false)).Any(y => y == donation.Status));
            }

            return await entity.GetPagedAsync<Donation, DonationDTO>(_mapper, request.Page, request.PageSize, request.Paginate);
        }

        public async Task<DriveDetailsDTO> Details(string id)
        {
            var entity = await _context.Drives.Include(x => x.Donations).Where(x => x.DriveId == id).FirstAsync();

            return _mapper.Map<DriveDetailsDTO>(entity);
        }

    }
}
