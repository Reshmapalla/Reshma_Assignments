using JeansAppAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace JeansAppAPI.Repository
{
    public class ProductRepository:IProductRepository
    {
        private readonly JeansStationDBContext _dbContext;
        // Constructor to inject the DbContext dependency
        public ProductRepository(JeansStationDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        // Asynchronously adds a new product to the repository
        public async Task AddProduct(Product product)
        {
            try
            {
                await _dbContext.Products.AddAsync(product); // Add the product to the context
                await _dbContext.SaveChangesAsync(); // Save changes to the database
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while registering the user: {ex.Message}");
            }
        }


        // Asynchronously deletes a product by its ProductId
        public async Task Delete(Guid ProductId)
        {
            try
            {
                var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.ProductId == ProductId);
                if (product != null)
                {
                    _dbContext.Products.Remove(product);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    // Handle the case where the product is not found
                    Console.WriteLine("Product not found.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine("An error occurred while deleting the product: " + ex.Message);
                throw;
            }
        }


        // Asynchronously retrieves a list of all products
        public async Task<List<Product>> GetAllProducts()
        {
            try
            {
                return await _dbContext.Products.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
              throw new Exception(ex.Message);
            }
        }

        // Asynchronously retrieves a specific product by its ProductId
        public async Task<Product> GetProductById(Guid ProductId)
        {
            try
            {
                return await _dbContext.Products.FindAsync(ProductId);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine("An error occurred while retrieving the product: " + ex.Message);
                throw;
            }
        }

        // Asynchronously updates an existing product
        public async Task Update(Product product)
        {
            try
            {
                _dbContext.Products.Update(product);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine("An error occurred while updating the product: " + ex.Message);
                throw;
            }
        }
    }
}
