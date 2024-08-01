using System.ComponentModel.DataAnnotations;

namespace GasBookingApplication.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string Status { get; set; }


    }
}
