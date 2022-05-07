using System;
using System.Collections.Generic;
using System.Text;

namespace Vivel.Model.Requests.User
{
    public class AdminStaffUpdateRequest : AdminUserUpdateRequest
    {
        public Dictionary<string, string> Claims { get; set; }
    }
}
