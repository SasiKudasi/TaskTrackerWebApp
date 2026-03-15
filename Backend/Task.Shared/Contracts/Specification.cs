using System;
using System.Collections.Generic;
using System.Text;

namespace Task.Shared.Contracts
{
    public class Specification
    {
        public int PageSize { get; set; } = 10;
        public int PageNum { get; set; } = 1;
        public string Sorting { get; set; } = "desc";
    }
}
