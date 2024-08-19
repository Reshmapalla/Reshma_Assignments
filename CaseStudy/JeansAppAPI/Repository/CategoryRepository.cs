using JeansAppAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeansAppAPI.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly JeansStationDBContext _context;
        // Constructor to inject the DbContext dependency
        public CategoryRepository(JeansStationDBContext context)
        {
            // Check if the provided context argument is null.
            // If it is null, throw an ArgumentNullException with the parameter name 'context'.
            // This ensures that the controller cannot be instantiated without a valid repository.
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }


        public async Task<List<Category>> GetAllCategories()
        {
            try
            {
                // Retrieve all categories from the database
                return await _context.Categories.ToListAsync();
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the retrieval
                throw new Exception(ex.Message);
            }
        }


        public async Task<Category> GetCategoryById(Guid id)
        {
            try
            {
                // Attempt to find the category by its ID
                var category = await _context.Categories.FindAsync(id);

                // Check if the category was found
                if (category == null)
                {
                    throw new KeyNotFoundException($"Category with ID '{id}' not found.");
                }

                // Return the found category
                return category;
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the retrieval
                throw new Exception("An error occurred while retrieving the category.", ex);
            }
        }



        public async Task DeleteCategory(Guid id)
        {
            try
            {
                // Attempt to find the category by its ID
                var category = await _context.Categories.FindAsync(id);

                // Check if the category was found
                if (category == null)
                {
                    throw new KeyNotFoundException($"Category with ID '{id}' not found.");
                }

                // Remove the category from the database
                _context.Categories.Remove(category);

                // Save the changes to the database
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the deletion
                throw new Exception("An error occurred while deleting the category.", ex);
            }
        }



        public async Task UpdateCategory(Category category)
        {
            if (category == null)
            {
                // Handle the case where the category is null
                throw new ArgumentNullException(nameof(category), "Category cannot be null.");
            }

            try
            {
                // Update the category in the database
                _context.Categories.Update(category);

                // Save the changes to the database
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the update
                throw new Exception("An error occurred while updating the category.", ex);
            }
        }



        public async Task AddCategory(Category category)
        {
            

            try
            {
                // Add the new category to the database
                await _context.Categories.AddAsync(category);

                // Save the changes to the database
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the addition
                throw new Exception("An error occurred while adding the category.", ex);
            }
        }

    }
}

