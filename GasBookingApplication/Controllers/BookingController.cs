using GasBookingApp.Models;
using GasBookingApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GasBookingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly GasBookingDBContext _context;
        public BookingController(GasBookingDBContext context)
        {
            _context = context;


        }

        [HttpGet("GetBookings")]
        public List<Booking> GetBookings()
        {

            List<Booking> bookings = _context.Bookings.ToList();


            return bookings;


        }

        [HttpPost]
        public IActionResult Post([FromBody] Booking bookings)
        {

            try
            {
               
                /*if (existingUser != null)
                {
                    return BadRequest("Email is already registered. Please login.");

                }*/
                _context.Bookings.Add(bookings);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
            return Created("bookings Added", "bookings Added");



        }


        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Find the entity by id
                Booking bookings = _context.Bookings.Find(id);
                if (bookings == null)
                {
                    return NotFound("Record not found.");
                }

                // Remove the entity from the context
                _context.Bookings.Remove(bookings);

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
        public IActionResult Update(int id, [FromBody] Booking updatedbookings)
        {
            try
            {
                var bookings = _context.Bookings.Find(id);
                if (bookings == null)
                {
                    return NotFound("Record not found.");
                }

                // Update properties
              //  bookings.BookId = updatedbookings.BookId;
              //  bookings.PayId = updatedbookings.PayId;
              //  bookings.UserId = updatedbookings.UserId;
                bookings.status = updatedbookings.status;
                bookings.BookingDate = updatedbookings.BookingDate;


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
