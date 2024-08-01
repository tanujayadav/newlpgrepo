using System.ComponentModel.DataAnnotations;

namespace GasBookingApplication.Models
{
    public class Payment
    {

        [Key]
        public int PayId { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentType { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }

       // public User User { get; set; }
    }
}
