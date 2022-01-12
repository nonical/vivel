using System;
using System.Collections.Generic;

#nullable disable

namespace Vivel.Database
{
    public partial class User
    {
        public User()
        {
            Badges = new HashSet<Badge>();
            Donations = new HashSet<Donation>();
            Notifications = new HashSet<Notification>();
        }

        public string UserId { get; set; }
        public string BloodType { get; set; }
        public bool? Verified { get; set; }

        public virtual ICollection<Badge> Badges { get; set; }
        public virtual ICollection<Donation> Donations { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
