using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Service.DataTransferObjects
{
    public class PaginatedRes<T>
    {
        public int TotalItems { get; set; }    
        public int PageSize { get; set; }         
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public IEnumerable<T> Data { get; set; } = [];
    }
}
