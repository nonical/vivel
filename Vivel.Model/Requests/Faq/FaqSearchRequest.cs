using System;
using System.Collections.Generic;
using System.Text;

namespace Vivel.Model.Requests.Faq
{
    public class FaqSearchRequest : BaseSearchObject
    {
        public bool? Answered { get; set; }
    }
}
