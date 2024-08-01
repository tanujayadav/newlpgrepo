using GasBookingApp.Models;
using GasBookingApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GasBookingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealerController : ControllerBase
    {
        private readonly GasBookingDBContext _context;
        public DealerController(GasBookingDBContext context)
        {
            _context = context;


        }

        [HttpGet("GetDealer")]
        public List<Dealer> GetDealer()
        {

            List<Dealer> dealers = _context.Dealers.ToList();


            return dealers;


        }

        [HttpPost]
        public IActionResult Post([FromBody] Dealer dealers)
        {

            try
            {

                /*if (existingUser != null)
                {
                    return BadRequest("Email is already registered. Please login.");

                }*/
                _context.Dealers.Add(dealers);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
            return Created("dealers Added", "dealers Added");



        }


        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Find the entity by id
                Dealer dealers = _context.Dealers.Find(id);
                if (dealers == null)
                {
                    return NotFound("Record not found.");
                }

                // Remove the entity from the context
                _context.Dealers.Remove(dealers);

                // Save changes to the database
                _context.SaveChanges();

                return Ok("Record deleted successfully.");
            }

            catch (Exception ex)
            {
                // Log the exception message for debugging purposes
                Console.WriteLine(ex.Message);
                return BadRequest("Deletion error. Please try again later.");
            }
        }


        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] Dealer updateddealers)
        {
            try
            {
                var dealers = _context.Dealers.Find(id);
                if (dealers == null)
                {
                    return NotFound("Record not found.");
                }

                // Update properties
                //  bookings.BookId = updatedbookings.BookId;
                // bookings.PayId = updatedbookings.PayId;
                // bookings.UserId = updatedbookings.UserId;
                dealers.DealerName = updateddealers.DealerName;
                dealers.City = updateddealers.City;
                dealers.Phone = updateddealers.Phone;


                _context.SaveChanges();

                return Ok("Record updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest("Update error. Please try again later.");
            }
        }



    }
}
