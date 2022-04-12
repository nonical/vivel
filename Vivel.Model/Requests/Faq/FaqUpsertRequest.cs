using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vivel.Model.Requests.Faq
{
    public class FaqUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Question { get; set; }
        public string Answer { get; set; }
        public bool Answered { get; set; } = false;
    }
}
