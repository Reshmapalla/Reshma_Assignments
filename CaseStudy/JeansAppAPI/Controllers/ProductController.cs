using JeansAppAPI.Entities;
using JeansAppAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JeansAppAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }
        [Authorize(Roles = "Admin,Customer")]
        // Asynchronously retrieves all products
        [HttpGet, Route("GetAllProducts")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _repository.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [Authorize(Roles = "Admin,Customer")]
        // Asynchronously retrieves a product by its ID
        [HttpGet, Route("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] Guid id)
        {
            try
            {
                var product = await _repository.GetProductById(id);
                if (product != null)
                {
                    return Ok(product);
                }
                else
                {
                    return NotFound("Product not found.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [Authorize(Roles = "Admin")]
        // Asynchronously adds a new product
        [HttpPost, Route("AddProduct")]

 public async Task<IActionResult> Add([FromBody] Product product)
 {
     try
     {
         if (ModelState.IsValid)
         {
             product.ProductId = Guid.NewGuid();
             await _repository.AddProduct(product);
             return StatusCode(200, product);
         }
         else
         {
             return BadRequest("Enter Valid Details!");
         }
     }
     catch (Exception ex)
     {
         return BadRequest(ex.Message);
     }
 }
        [Authorize(Roles = "Admin")]
        // Asynchronously updates an existing product
        [HttpPut, Route("EditProduct")]
        public async Task<IActionResult> Update([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.Update(product);
                    return Ok(product);
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it as needed
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
            else
            {
                return BadRequest("Invalid product details.");
            }
        }
        [Authorize(Roles = "Admin")]
        // Asynchronously deletes a product by its ID
        [HttpDelete, Route("DeleteProduct/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                await _repository.Delete(id);
                return Ok(new { Message = "Product deleted successfully.", ProductId = id });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
