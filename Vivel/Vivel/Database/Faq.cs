using System;
using System.Collections.Generic;

#nullable disable

namespace Vivel.Database
{
    public partial class Faq : BaseModel
    {
        public string Faqid { get; set; } = Guid.NewGuid().ToString();
        public string Question { get; set; }
        public string Answer { get; set; }
        public bool? Answered { get; set; } = false;
    }
}
