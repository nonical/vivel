using System.ComponentModel.DataAnnotations;

namespace Vivel.Model.Requests.User
{
    public class UserUpdateRequest
    {
        [Required]
        public string BloodType { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
