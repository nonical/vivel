using System.ComponentModel.DataAnnotations;

namespace Vivel.Model.Requests.User
{
    public class UserUpdateRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
