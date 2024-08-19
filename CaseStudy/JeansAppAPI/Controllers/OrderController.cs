using JeansAppAPI.Entities;
using JeansAppAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace JeansAppAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _repository;

        public OrderController(IOrderRepository repository)
        {
            _repository = repository;
        }
        [Authorize(Roles = "Admin,Customer")]

        [HttpGet, Route("GetAllOrders")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var orders = await _repository.GetAllOrders(); // Retrieves all Orders asynchronously.
                return StatusCode(200, orders); // Returns the Orders with a 200 OK status.
            }
            catch (Exception ex)
            {
                // Log the exception (logging implementation not shown here)
                return StatusCode(500, $"An error occurred: {ex.Message}"); // Returns a 500 Internal Server Error with the exception message.
            }
        }
        [Authorize(Roles = "Admin,Customer")]
        [HttpGet, Route("GetOrderById/{id}")]
        public async Task<IActionResult> GetOrderById([FromRoute] Guid id)
        {
            try
            {
                var order = await _repository.GetOrderById(id); // Retrieves the Order by ID asynchronously.
                if (order != null)
                {
                    return StatusCode(200, order); // Returns the Order with a 200 OK status.
                }
                else
                {
                    return StatusCode(404, "Invalid Id"); // Returns a 404 Not Found if the Order is not found.
                }
            }
            catch (Exception ex)
            {
                // Log the exception (logging implementation not shown here)
                return StatusCode(500, $"An error occurred: {ex.Message}"); // Returns a 500 Internal Server Error with the exception message.
            }
        }
        [Authorize(Roles = "Customer")]

        [HttpPost, Route("AddOrder")]
      
        public async Task<IActionResult> Add([FromBody] Order order)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    order.OrderId = Guid.NewGuid(); // Generates a new OrderId.
                    await _repository.Add(order); // Adds the Order asynchronously.
                    return StatusCode(200, order); // Returns the newly created Order with a 200 OK status.
                }
                catch (Exception ex)
                {
                    // Log the exception (logging implementation not shown here)
                    return StatusCode(500, $"An error occurred: {ex.Message}"); // Returns a 500 Internal Server Error with the exception message.
                }
            }
            else
            {
                return BadRequest("Enter valid details"); // Returns a 400 Bad Request if the model state is invalid.
            }
        }
        [Authorize(Roles = "Customer")]
        [HttpDelete, Route("DeleteOrder")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _repository.Delete(id); // Deletes the Order by ID asynchronously.
                return Ok(id); // Returns a 200 OK status with the deleted Order ID.
            }
            catch (Exception ex)
            {
                // Log the exception (logging implementation not shown here)
                return StatusCode(500, $"An error occurred: {ex.Message}"); // Returns a 500 Internal Server Error with the exception message.
            }
        }
    }
}
