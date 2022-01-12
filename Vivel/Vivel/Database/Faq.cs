using System;
using System.Collections.Generic;

#nullable disable

namespace Vivel.Database
{
    public partial class Faq
    {
        public string Faqid { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public bool? Answered { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
