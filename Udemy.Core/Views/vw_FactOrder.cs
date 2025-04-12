using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Core.Views
{
    public class vw_FactOrder
    {
        public int? OrderId { get; set; }
        public int? StudentId { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Status { get; set; }
        public int? TotalAmount { get; set; }
        public decimal? Discount { get; set; }
        public int? OrderDateKey { get; set; }
        public int? ModifiedDateKey { get; set; }
    }
}
