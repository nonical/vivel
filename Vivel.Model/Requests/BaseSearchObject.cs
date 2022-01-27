using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vivel.Model.Requests
{
    public class BaseSearchObject
    {
        [Range(1, int.MaxValue, ErrorMessage = "Page must be greater than 1")]
        public int Page { get; set; } = 1;
    }
}
