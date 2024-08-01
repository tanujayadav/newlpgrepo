using System.ComponentModel.DataAnnotations;

namespace GasBookingApplication.Models
{
    public class Review
    {

        [Key]
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public string GasName { get; set; }
        public string ReviewText { get; set; }

       // public User User { get; set; }
       // public Gas Gas { get; set; }
    }
}
