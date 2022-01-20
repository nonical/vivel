using System;
using System.Collections.Generic;
using System.Text;

namespace Vivel.Model.Dto
{
    public class UserDetailsDTO : UserDTO
    {
        public int DonationCount { get; set; }
        public decimal LitresDonated { get; set; }
        public DateTime? LastDonation { get; set; }
    }
}
