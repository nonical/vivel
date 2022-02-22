namespace Vivel.Model.Dto
{
    public class UserDTO
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string BloodType { get; set; }
        public bool? Verified { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
