using GasBookingApp.Models;
using GasBookingApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GasBookingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly GasBookingDBContext _context;
        public PaymentController(GasBookingDBContext context)
        {
            _context = context;


        }

        [HttpGet("GetPayments")]
        public List<Payment> GetPayments()
        {

            List<Payment> payments = _context.Payments.ToList();


            return payments;


        }


        [HttpPost]
        public IActionResult Post([FromBody] Payment payments)
        {

            try
            {

                /*if (existingUser != null)
                {
                    return BadRequest("Email is already registered. Please login.");

                }*/
                _context.Payments.Add(payments);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
            return Created("payments Added", "payments Added");



        }


        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Find the entity by id
                Payment payments = _context.Payments.Find(id);
                if (payments == null)
                {
                    return NotFound("Record not found.");
                }

                // Remove the entity from the context
                _context.Payments.Remove(payments);

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
        public IActionResult Update(int id, [FromBody] Payment updatedpayments)
        {
            try
            {
                var payments = _context.Payments.Find(id);
                if (payments == null)
                {
                    return NotFound("Record not found.");
                }

                // Update properties
                //  payments.PayId = updatedpayments.PayId;
                // payments.UserId = updatedpayments.UserId;
                payments.TotalPrice = updatedpayments.TotalPrice;
                payments.PaymentType = updatedpayments.PaymentType;
                payments.Date = updatedpayments.Date;
                payments.Status = updatedpayments.Status;


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
