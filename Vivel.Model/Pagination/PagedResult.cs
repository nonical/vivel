﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Vivel.Model.Pagination
{
    public class PagedResult<T>
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int TotalItems { get; set; }
        public IList<T> Results { get; set; }

    }
}
