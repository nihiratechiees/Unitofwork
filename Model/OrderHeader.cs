using System.ComponentModel.DataAnnotations;

namespace Unitofwork.Model
{
    public class OrderHeader
    {
        [Key]
       public string OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerId { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
