using System;
using System.Collections.Generic;
using System.Text;

namespace Vivel.Model.Requests.User
{
    public class UserSearchRequest
    {
        public string BloodType { get; set; }
        public bool? Verified { get; set; }
    }
}
