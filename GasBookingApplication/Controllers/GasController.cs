using GasBookingApp.Models;
using GasBookingApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GasBookingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GasController : ControllerBase
    {
        private readonly GasBookingDBContext _context;
        public GasController(GasBookingDBContext context)
        {
            _context = context;


        }

        [HttpGet("GetGases")]
        public List<Gas> GetGases()
        {

            List<Gas> gases = _context.Gases.ToList();


            return gases;


        }


        [HttpPost]
        public IActionResult Post([FromBody] Gas gases)
        {

            try
            {

                /*if (existingUser != null)
                {
                    return BadRequest("Email is already registered. Please login.");

                }*/
                _context.Gases.Add(gases);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
            return Created("gases Added", "gases Added");



        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Find the entity by id
                Gas gases = _context.Gases.Find(id);
                if (gases == null)
                {
                    return NotFound("Record not found.");
                }

                // Remove the entity from the context
                _context.Gases.Remove(gases);

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
        public IActionResult Update(int id, [FromBody] Gas updatedgases)
        {
            try
            {
                var gases = _context.Gases.Find(id);
                if (gases == null)
                {
                    return NotFound("Record not found.");
                }

                // Update properties
                //  gases.GasId = updatedgases.GasId;
                gases.GasName = updatedgases.GasName;
                // gases.DealerId = updatedgases.DealerId;
                
                gases.Price = updatedgases.Price;
                gases.City = updatedgases.City;
                gases.Address = updatedgases.Address;
                gases.Availability = updatedgases.Availability;
                gases.Quantity = updatedgases.Quantity;
                gases.Description = updatedgases.Description;

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
