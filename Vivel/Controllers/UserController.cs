﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Vivel.Model.Dto;
using Vivel.Model.Requests.User;
using Vivel.Services;

namespace Vivel.Controllers
{
    public class UserController : BaseCRUDController<UserDTO, UserSearchRequest, object, UserUpdateRequest>
    {
        public UserController(IUserService service) : base(service) { }

        [NonAction]
        public override Task<UserDTO> Insert([FromBody] object request)
        {
            return base.Insert(request);
        }
    }
}
