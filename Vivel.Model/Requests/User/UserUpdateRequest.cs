using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Ardalis.SmartEnum.SystemTextJson;
using Vivel.Model.Enums;

namespace Vivel.Model.Requests.User
{
    public class UserUpdateRequest
    {
        [Required]
        [JsonConverter(typeof(SmartEnumNameConverter<BloodType, int>))]
        public BloodType BloodType { get; set; }
        [Required]
        public bool Verified { get; set; }
    }
}
