﻿using Vivel.Model.Requests.Faq;
using Vivel.Services;
using Vivel.Model.Dto;
using Vivel.Model.Requests.Hospital;

namespace Vivel.Controllers
{
    public class HospitalController : BaseCRUDController<HospitalDTO, HospitalSearchRequest, HospitalInsertRequest, HospitalUpdateRequest>
    {
        public HospitalController(IHospitalService service) : base(service)
        {
        }
    }
}
