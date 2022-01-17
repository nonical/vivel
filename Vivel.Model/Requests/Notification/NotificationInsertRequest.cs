using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vivel.Model.Requests.Notification
{
    public class NotificationInsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Content { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string UserId { get; set; }        
        
        [Required(AllowEmptyStrings = false)]
        public string LinkId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string LinkType { get; set; }
    }
}
