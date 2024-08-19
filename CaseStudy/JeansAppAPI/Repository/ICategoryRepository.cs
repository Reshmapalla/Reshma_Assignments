using JeansAppAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeansAppAPI.Repository
{
    public interface ICategoryRepository
    {
        
            // Retrieve all categories
            Task<List<Category>> GetAllCategories();

            // Retrieve a category by its ID
            Task<Category> GetCategoryById(Guid id);

            // Delete a category by its ID
            Task DeleteCategory(Guid id);

            // Update an existing category
            Task UpdateCategory(Category category);

            // Add a new category
            Task AddCategory(Category category);
        

    }
}

