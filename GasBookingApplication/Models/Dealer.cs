using System.ComponentModel.DataAnnotations;

namespace GasBookingApplication.Models
{
    public class Dealer
    {

        [Key]
        public int DealerId { get; set; }
        public string DealerName { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }

      

        //public ICollection<Gas> Gases { get; set; }

    }
}
