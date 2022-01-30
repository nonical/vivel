using System.Collections.Generic;

namespace Vivel.Model.Requests.User
{
    public class UserSearchRequest : BaseSearchObject
    {
        public string UserName { get; set; }
        public List<string> BloodType { get; set; }
        public bool? Verified { get; set; }
    }
}
