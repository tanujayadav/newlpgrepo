using GasBookingApp.Models;
using GasBookingApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GasBookingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly GasBookingDBContext _context;
        public OrderController(GasBookingDBContext context)
        {
            _context = context;


        }

        [HttpGet("GetOrders")]
        public List<Order> GetOrders()
        {

            List<Order> orders = _context.Orders.ToList();


            return orders;


        }

        [HttpGet("GetOrderBySignupId")]
        public IActionResult GetOrderBySignupId(int id)
        {

            var order = _context.Orders.Where(item => item.CustomerId == id).ToList();
            if (order.Any())
            {
                return Ok(order);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public IActionResult Post([FromBody] Order orders)
        {

            try
            {

                /*if (existingUser != null)
                {
                    return BadRequest("Email is already registered. Please login.");

                }*/
                _context.Orders.Add(orders);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
            return Created("Orders Added", "Orders Added");



        }
    }
}
