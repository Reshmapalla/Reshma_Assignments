using JeansAppAPI.Entities;
using JeansAppAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System;
using System.Threading.Tasks;

namespace JeansAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteController : ControllerBase
    {
        private readonly IFavouriteRepository _favouriteRepository;

        public FavouriteController(IFavouriteRepository favouriteRepository)
        {
            _favouriteRepository = favouriteRepository ?? throw new ArgumentNullException(nameof(favouriteRepository));
        }

        // GET: api/Favourite/GetFavourites
        [Authorize(Roles = "Admin,Customer")]
        [HttpGet, Route("GetFavourites")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var favorites = await _favouriteRepository.GetAllFavourites();
                return Ok(favorites);
            }
            catch (Exception ex)
            {
                // Log the exception (logging not implemented here)
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Favourite/GetFavoritesbyid/{id}
        [Authorize(Roles = "Admin,Customer")]
        [HttpGet, Route("GetFavoritesbyid/{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            try
            {
                var favorite = await _favouriteRepository.GetFavouriteById(id);
                if (favorite != null)
                {
                    return Ok(favorite);
                }
                else
                {
                    return NotFound("Invalid Id");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Favourite/AddFavorite
        [Authorize(Roles = "Customer")]
        [HttpPost, Route("AddFavorite")]
        public async Task<IActionResult> Add([FromBody] Favourite favourite)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    favourite.FavoriteId = Guid.NewGuid();
                    await _favouriteRepository.Add(favourite);
                    return Ok(favourite);
                }
                else
                {
                    return BadRequest("Enter valid details");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Favourite/EditFavourite
        [Authorize(Roles = "Customer")]
        [HttpPut, Route("EditFavourite")]
        public async Task<IActionResult> Edit([FromBody] Favourite favorite)
        {
            try
            {
                await _favouriteRepository.Update(favorite);
                return Ok(favorite);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Favourite/DeleteFavourite
        [Authorize(Roles = "Customer")]
        [HttpDelete, Route("DeleteFavourite")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            try
            {
                await _favouriteRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

