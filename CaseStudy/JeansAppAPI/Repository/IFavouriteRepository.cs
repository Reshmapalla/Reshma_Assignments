using JeansAppAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeansAppAPI.Repository
{
    public interface IFavouriteRepository
    {
        // Asynchronously adds a new favourite item
        Task Add(Favourite favourite);

        // Asynchronously retrieves a favourite item by its ID
        Task<Favourite> GetFavouriteById(Guid favouriteId);

        // Asynchronously retrieves all favourite items
        Task<List<Favourite>> GetAllFavourites();

        // Asynchronously deletes a favourite item by its ID
        Task Delete(Guid id);

        // Asynchronously updates an existing favourite item
        Task Update(Favourite favourite);
    }
}

