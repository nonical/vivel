using System;
using System.Threading.Tasks;
using Vivel.Model.Dto;
using Vivel.Model.Pagination;
using Vivel.Model.Requests.Donation;
using Vivel.Model.Requests.Drive;

namespace Vivel.Interfaces
{
    public interface IDriveService : IBaseCRUDService<DriveDTO, DriveSearchRequest, DriveInsertRequest, DriveUpdateRequest>
    {
        Task<PagedResult<DonationDTO>> Donations(Guid id, DonationSearchRequest request);
        Task<DriveDetailsDTO> Details(Guid id);
    }
}
