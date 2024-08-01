using GasBookingApp.Models;
using GasBookingApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GasBookingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly GasBookingDBContext _context;
        public ReviewController(GasBookingDBContext context)
        {
            _context = context;


        }

        [HttpGet("GetReviews")]
        public List<Review> GetReviews()
        {

            List<Review> reviews = _context.Reviews.ToList();


            return reviews;


        }

        [HttpGet("GetReviewBySignupId")]
        public IActionResult GetReviewBySignupId(int id)
        {

            var review = _context.Reviews.Where(item => item.UserId == id).ToList();
            if (review.Any())
            {
                return Ok(review);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public IActionResult Post([FromBody] Review reviews)
        {

            try
            {

                /*if (existingUser != null)
                {
                    return BadRequest("Email is already registered. Please login.");

                }*/
                _context.Reviews.Add(reviews);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
            return Created("reviews Added", "reviews Added");



        }


        [HttpGet("GetReviewById/{id}")]
        public IActionResult GetReviewById(int id)
        {

            var review = _context.Reviews.Find(id);



            return Ok(review);


        }



        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Find the entity by id
                Review reviews= _context.Reviews.Find(id);
                if (reviews == null)
                {
                    return NotFound("Record not found.");
                }

                // Remove the entity from the context
                _context.Reviews.Remove(reviews);

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



       /* [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] Review updatedreviews)
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
                // bookings.PayId = updatedbookings.PayId;
                // bookings.UserId = updatedbookings.UserId;
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
        }*/


    }
}
