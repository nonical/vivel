﻿using System.ComponentModel.DataAnnotations;

namespace Vivel.Model.Requests.User
{
    public class UserUpdateRequest
    {
        [Required]
        public string BloodType { get; set; }
        [Required]
        public bool Verified { get; set; }
    }
}
