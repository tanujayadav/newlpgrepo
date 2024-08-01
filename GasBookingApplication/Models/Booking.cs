using System.ComponentModel.DataAnnotations;

namespace GasBookingApplication.Models
{
    public class Booking
    {

        [Key]
        
        public int BookId { get; set; }
        public int PayId { get; set; }
        public int UserId { get; set; }

        public string status { get;set; }
        public DateTime BookingDate { get; set; }

       // public Payment Payment { get; set; }
        //public User User { get; set; }
    }
}
