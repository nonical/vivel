using System;
using System.Collections.Generic;
using System.Text;

namespace Vivel.Model.Requests.Notification
{
    public class NotificationSearchRequest : BaseSearchObject
    {
        public string LinkId { get; set; }
        public string LinkType { get; set; }
    }
}
