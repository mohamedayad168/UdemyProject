using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Core.Entities
{
   public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public int TotalAmount { get; set; }

        public decimal? Discount { get; set; }

        // Navigation Property
        public Student Student { get; set; }
    }

    public enum PaymentMethod
    {
        CreditCard,
        PayPal,
        BankTransfer,
        Cash
    }

    public enum OrderStatus
    {
        Pending,
        Completed,
        Cancelled
    }
}
