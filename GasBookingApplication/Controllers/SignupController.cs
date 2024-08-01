using GasBookingApp.Models;
using GasBookingApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GasBookingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        private readonly GasBookingDBContext _context;
        public SignupController(GasBookingDBContext context)
        {
            _context = context;


        }

        [HttpGet("GetSignup")]
        public List<user> GetSignup()
        {

            List<user> signup = _context.Users.ToList();


            return signup;


        }

        [HttpPost]
        public IActionResult Post([FromBody] user signup)
        {

            try
            {
                var existingUser = _context.Users.FirstOrDefault(u => u.Email == signup.Email);
                /*if (existingUser != null)
                {
                    return BadRequest("Email is already registered. Please login.");

                }*/
                _context.Users.Add(signup);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();

            }
            return Created("user Added", "user Added");



        }





        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Find the entity by id
                user signup = _context.Users.Find(id);
                if (signup == null)
                {
                    return NotFound("Record not found.");
                }

                // Remove the entity from the context
                _context.Users.Remove(signup);

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
        public IActionResult Update(int id, [FromBody] user updatedSignup)
        {
            try
            {
                var signup = _context.Users.Find(id);
                if (signup == null)
                {
                    return NotFound("Record not found.");
                }

                // Update properties
                signup.Username = updatedSignup.Username;
                signup.Password = updatedSignup.Password;
                signup.Name = updatedSignup.Name;
                signup.Email = updatedSignup.Email;
                
                signup.Address = updatedSignup.Address;
                signup.PhoneNo= updatedSignup.PhoneNo;

                _context.SaveChanges();

                return Ok("Record updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest("Update error. Please try again later.");
            }
        }

        [HttpGet("GetSignupIdByEmail")]
        public IActionResult GetSignupIdByEmail(string email)
        {

            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                return Ok(user.Id);
            }
            else
            {
                return NotFound("0");
            }

        }

        [HttpGet("GetSignupById/{id}")]
        public IActionResult GetSignupById(int id)
        {

            var signup = _context.Users.Find(id);



            return Ok(signup);


        }



    }

}
