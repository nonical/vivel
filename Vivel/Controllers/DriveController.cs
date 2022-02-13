using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Pagination;
using Vivel.Model.Requests.Donation;
using Vivel.Model.Requests.Drive;

namespace Vivel.Controllers
{
    public class DriveController : BaseCRUDController<DriveDTO, DriveSearchRequest, DriveInsertRequest, DriveUpdateRequest>
    {
        private readonly IDriveService _driveService;
        public DriveController(IDriveService service) : base(service)
        {
            _driveService = service;
        }

        [HttpGet("{id}/donations")]
        public Task<PagedResult<DonationDTO>> Donations(string id, [FromQuery] DonationSearchRequest request)
        {
            return _driveService.Donations(id, request);
        }

        [HttpGet("{id}/details")]
        public Task<DriveDetailsDTO> Details(string id)
        {
            return _driveService.Details(id);
        }
    }
}
