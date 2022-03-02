using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;
using Vivel.Model.Enums;

#nullable disable

namespace Vivel.Database
{
    public partial class User : BaseModel
    {
        public User()
        {
            Badges = new HashSet<Badge>();
            Donations = new HashSet<Donation>();
            Notifications = new HashSet<Notification>();
        }

        public string UserId { get; set; } = Guid.NewGuid().ToString();
        public string UserName { get; set; }
        public BloodType BloodType { get; set; }
        public bool? Verified { get; set; } = false;
        public Point Location { get; set; }

        public virtual ICollection<Badge> Badges { get; set; }
        public virtual ICollection<Donation> Donations { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
