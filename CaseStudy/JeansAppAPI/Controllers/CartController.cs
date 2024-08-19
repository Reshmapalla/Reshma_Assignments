using JeansAppAPI.Entities;
using JeansAppAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JeansAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository)); // Initialize the repository
        }

        [Authorize(Roles = "Admin,Customer")]
        [HttpGet, Route("GetAllCartItems")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var cartItems = await _cartRepository.GetAllCartItems(); // Retrieve all cart items
                return Ok(cartItems); // Return 200 OK with cart items
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); // Handle exceptions
            }
        }

        [Authorize(Roles = "Admin,Customer")]
        [HttpGet, Route("GetCartItemById/{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            try
            {
                var cartItem = await _cartRepository.GetCartitemById(id); // Retrieve a specific cart item by ID
                return Ok(cartItem); // Return 200 OK with the cart item
            }
           
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); // Handle exceptions
            }
        }

        [Authorize(Roles = "Customer")]
        [HttpPost, Route("AddCartItem")]
        public async Task<IActionResult> Add([FromBody] CartItem cartItem)
        {
            try
            {
                cartItem.CartId= Guid.NewGuid();
                await _cartRepository.AddCartItem(cartItem); // Add a new cart item
                return CreatedAtAction(nameof(Get), new { id = cartItem.CartId }, cartItem); // Return 201 Created with the cart item
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); // Handle exceptions
            }
        }
        [Authorize(Roles = "Customer")]
        [HttpPut, Route("UpdateCartItem")]

        public async Task<IActionResult> Update([FromBody] CartItem cartItem)
        {
            try
            {
                await _cartRepository.Update(cartItem); // Update an existing cart item
                return Ok(cartItem); // Return 200 OK with the updated cart item
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); // Handle exceptions
            }
        }
        [Authorize(Roles = "Customer")]
        [HttpDelete, Route("DeleteCartItem")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            try
            {
                await _cartRepository.Delete(id); // Delete a cart item by ID
                return Ok("Cart item deleted successfully"); // Return 200 OK if deletion is successful
            }
           
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); // Handle exceptions
            }
        }
    }
}

