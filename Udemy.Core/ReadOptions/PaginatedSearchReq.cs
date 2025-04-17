using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Core.ReadOptions
{
    public class PaginatedSearchReq: RequestParamter
    {
        public string? SearchTerm { get; set; } = "";
        public string? OrderBy { get; set; } = "title";
    }
}
