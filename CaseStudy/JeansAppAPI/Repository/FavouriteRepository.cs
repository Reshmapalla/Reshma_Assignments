using JeansAppAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeansAppAPI.Repository
{
    public class FavouriteRepository : IFavouriteRepository
    {
        private readonly JeansStationDBContext _context;

        public FavouriteRepository(JeansStationDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); // Ensure context is not null
        }

        // Asynchronously adds a new favourite item
        public async Task Add(Favourite favourite)
        {
            try
            {
               await _context.Favourites.AddAsync(favourite);
                await _context.SaveChangesAsync(); // Save changes asynchronously
            }
            catch (Exception ex)
            {
                // Handle the exception (logging, rethrowing, etc.)
                Console.WriteLine($"An error occurred while registering the user: {ex.Message}");
            }
        }

        // Asynchronously deletes a favourite item by its ID
        public async Task Delete(Guid id)
        {
            try
            {
                var favourite = await _context.Favourites.FindAsync(id);
                _context.Favourites.Remove(favourite);
                await _context.SaveChangesAsync(); // Save changes asynchronously
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while registering the user: {ex.Message}");
            }
        }

        // Asynchronously retrieves all favourite items
        public async Task<List<Favourite>> GetAllFavourites()
        {
            try
            {
                return await _context.Favourites.ToListAsync(); // Retrieve all items asynchronously
            }
            catch (Exception ex)
            {
                // Handle the exception (logging, rethrowing, etc.)
                throw new Exception(ex.Message);
            }
        }

        // Asynchronously retrieves a favourite item by its ID
        public async Task<Favourite> GetFavouriteById(Guid favouriteId)
        {
            try
            {
                var favourite = await _context.Favourites.FindAsync(favouriteId);
                

                return favourite;
            }
            catch (Exception ex)
            {
                // Handle the exception (logging, rethrowing, etc.)
                throw new Exception(ex.Message);
            }
        }

        // Asynchronously updates an existing favourite item
        public async Task Update(Favourite favourite)
        {
            try
            {
                _context.Favourites.Update(favourite);
                await _context.SaveChangesAsync(); // Save changes asynchronously
            }
            catch (Exception ex)
            {
                // Handle the exception (logging, rethrowing, etc.)
                Console.WriteLine($"An error occurred while registering the user: {ex.Message}");
            }
        }
    }
}
