using System.ComponentModel.DataAnnotations;

namespace GasBookingApplication.Models
{
    public class user
    {

        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }

       // public ICollection<Payment> Payments { get; set; }
       // public ICollection<Booking> Bookings { get; set; }
       // public ICollection<Review> Reviews { get; set; }


    }
}
