﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vivel.Interfaces;
using Vivel.Model.Dto;
using Vivel.Model.Pagination;
using Vivel.Model.Requests.Faq;
using Vivel.Services;

namespace Vivel.Controllers
{
    public class FaqController : BaseCRUDController<FaqDTO, FaqSearchRequest, FaqInsertRequest, FaqUpdateRequest>
    {
        public FaqController(IFaqService service) : base(service)
        {
        }
        [Authorize(Roles = "admin,user")]

        public async override Task<PagedResult<FaqDTO>> Get([FromQuery] FaqSearchRequest request)
        {
            return await base.Get(request);
        }

        [Authorize(Roles = "admin,user")]
        public async override Task<ActionResult<FaqDTO>> GetById(string id)
        {
            return await base.GetById(id);
        }

        [Authorize(Roles = "admin,user")]
        public async override Task<ActionResult<FaqDTO>> Insert([FromBody] FaqInsertRequest request)
        {
            return await base.Insert(request);
        }

        [Authorize(Roles = "admin")]
        public async override Task<ActionResult<FaqDTO>> Update(string id, [FromBody] FaqUpdateRequest request)
        {
            return await base.Update(id, request);
        }
    }
}
