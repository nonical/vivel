﻿using System.Threading.Tasks;
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
        public async Task<PagedResult<DonationDTO>> Donations(string id, [FromQuery] DonationSearchRequest request)
        {
            return await _driveService.Donations(id, request);
        }

        [HttpGet("{id}/details")]
        public async Task<ActionResult<DriveDetailsDTO>> Details(string id)
        {
            var entity = await _driveService.Details(id);
            if (entity != null)
                return new OkObjectResult(entity);
            else
                return new NotFoundResult();
        }
    }
}
