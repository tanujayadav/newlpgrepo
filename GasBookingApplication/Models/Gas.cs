using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace GasBookingApplication.Models
{
    public class Gas
    {
        [Key]
        public int GasId { get; set; }
        public string GasName { get; set; }
        public int DealerId { get; set; }
        public decimal Price { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Availability { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
      //  public ICollection<Image> Images { get; set; }

      //  public Dealer Dealer { get; set; }
    }
}
