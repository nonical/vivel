using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vivel.Helpers;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Requests.Drive;
using Vivel.Model.Requests.Faq;
using Vivel.Model.Requests.Hospital;
using Vivel.Services;

namespace Vivel.Controllers
{
    public class HospitalController : BaseCRUDController<HospitalDTO, HospitalSearchRequest, HospitalUpsertRequest, HospitalUpsertRequest>
    {
        private readonly IHospitalService _hospitalService;
        public HospitalController(IHospitalService service) : base(service)
        {
            _hospitalService = service;
        }

        [HttpGet("{id}/drives")]
        public Task<PagedResult<DriveDTO>> Drives(string id, [FromQuery] DriveSearchRequest request)
        {
            return _hospitalService.Drives(id, request);
        }
    }
}
