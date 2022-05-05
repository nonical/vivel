using System;
using System.Collections.Generic;
using System.Text;

namespace Vivel.Model.Requests.User
{
    public class AdminUserUpdateRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
