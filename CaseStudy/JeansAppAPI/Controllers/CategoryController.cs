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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            // Ensure that the categoryRepository is not null
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        [Authorize(Roles = "Admin,Customer")]
        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                // Retrieve all categories using the repository
                var categories = await _categoryRepository.GetAllCategories();

                // Return the categories with an OK status
                return Ok(categories);
            }
            catch (Exception ex)
            {
                // Log the exception (logging not implemented here)
                return StatusCode(500, "An error occurred while retrieving categories.");
            }
        }


        [Authorize(Roles = "Admin,Customer")]
        [HttpGet("GetCategory/{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            try
            {
                // Attempt to retrieve the category by its ID
                var category = await _categoryRepository.GetCategoryById(id);

                // If the category exists, return it with an OK status
                if (category != null)
                {
                    return Ok(category);
                }

                // Return a NotFound status if the category doesn't exist
                return NotFound($"Category with ID '{id}' not found.");
            }
            catch (Exception ex)
            {
                // Log the exception (logging not implemented here)
                return StatusCode(500, "An error occurred while retrieving the category.");
            }
        }


        [Authorize(Roles = "Admin")]
        [HttpPost("AddCategory")]
        public async Task<IActionResult> Add([FromBody] Category category)
        {


            try
            {
                if (ModelState.IsValid)
                {
                    category.CategoryId = Guid.NewGuid();
                    await _categoryRepository.AddCategory(category);
                    return StatusCode(200, category);
                }
                else
                {
                    return BadRequest("Enter Valid Details!!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [Authorize(Roles = "Admin")]
        [HttpPut("EditCategory")]
        public async Task<IActionResult> Edit([FromBody] Category category)
        {
            if (category == null)
            {
                // Return a BadRequest status if the category is null
                return BadRequest("Category cannot be null.");
            }

            try
            {
                // Update the category using the repository
                await _categoryRepository.UpdateCategory(category);

                // Return an OK status with the updated category
                return Ok(category);
            }
            catch (Exception ex)
            {
                // Log the exception (logging not implemented here)
                return StatusCode(500, "An error occurred while updating the category.");
            }
        }

        [Authorize(Roles = "Admin")]

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            

            try
            {
                // Attempt to delete the category by its ID
                await _categoryRepository.DeleteCategory(id);
                //return deleted Category ````````````Id
                return Ok(id);
            }
            catch (Exception ex)
            {
                // Log the exception (logging not implemented here)
                return StatusCode(500, "An error occurred while deleting the category.");
            }
        }
    }
}

