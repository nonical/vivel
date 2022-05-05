using System.ComponentModel.DataAnnotations;

namespace Vivel.Model.Requests.User
{
    public class UserUpdateRequest
    {
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
