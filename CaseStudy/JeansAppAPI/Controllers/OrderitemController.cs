using JeansAppAPI.Entities;
using JeansAppAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace JeansAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderitemRepository _repository;

        public OrderItemsController(IOrderitemRepository repository)
        {
            _repository = repository;
        }
        [Authorize(Roles = "Customer")]
        [HttpPost,Route("AddOrderItems")]
        public async Task<IActionResult> Add([FromBody] OrderItems orderItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    orderItem.OrderItemId = Guid.NewGuid();
                    await _repository.AddOrderItems(orderItem);
                    return StatusCode(200, orderItem);
                }
                else
                {
                    return BadRequest("Enter Valid Details");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

            }
        [Authorize(Roles = "Admin,Customer")]
        [HttpGet, Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var orderItems = await _repository.GetAll(); // Retrieves all OrderItems asynchronously.
                return Ok(orderItems); // Returns the OrderItems with a 200 OK status.
            }
            catch (Exception ex)
            {
                // Log the exception (logging implementation not shown here)
                return StatusCode(500, $"An error occurred: {ex.Message}"); // Returns a 500 Internal Server Error with the exception message.
            }
        }
        [Authorize(Roles = "Admin,Customer")]
        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetOrderitemById([FromRoute] Guid id)
        {
            try
            {
                var orderItem = await _repository.GetOrderitemById(id); // Retrieves the OrderItem by ID asynchronously.
                if (orderItem != null)
                {
                    return Ok(orderItem); // Returns the OrderItem with a 200 OK status.
                }
                else
                {
                    return NotFound("Order item not found."); // Returns a 404 Not Found if the OrderItem is not found.
                }
            }
            catch (Exception ex)
            {
                // Log the exception (logging implementation not shown here)
                return StatusCode(500, $"An error occurred: {ex.Message}"); // Returns a 500 Internal Server Error with the exception message.
            }
        }
    }
}
