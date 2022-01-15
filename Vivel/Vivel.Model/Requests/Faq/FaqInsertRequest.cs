using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vivel.Model.Requests.Faq
{
    public class FaqInsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Question { get; set; }
    }
}
