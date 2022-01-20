using System.Text.Json.Serialization;
using Ardalis.SmartEnum.SystemTextJson;
using Vivel.Model.Enums;

namespace Vivel.Model.Requests.User
{
    public class UserSearchRequest
    {
        [JsonConverter(typeof(SmartEnumNameConverter<BloodType, int>))]
        public BloodType BloodType { get; set; }
        public bool? Verified { get; set; }
    }
}
