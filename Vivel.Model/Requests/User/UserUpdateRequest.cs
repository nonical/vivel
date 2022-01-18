using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vivel.Model.Requests.User
{
    public class UserUpdateRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string BloodType { get; set; }
        [Required]
        public bool Verified { get; set; }
    }
}
