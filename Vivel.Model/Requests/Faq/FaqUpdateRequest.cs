using System;
using System.Collections.Generic;
using System.Text;

namespace Vivel.Model.Requests.Faq
{
    public class FaqUpdateRequest
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public bool Answered { get; set; }
    }
}
