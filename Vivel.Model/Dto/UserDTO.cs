﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Vivel.Model.Dto
{
    public class UserDTO
    {
        public string UserId { get; set; }
        public string BloodType { get; set; }
        public bool? Verified { get; set; }
    }
}