using JeansAppAPI.Entities;

namespace JeansAppAPI.Repository
{
        public interface IProductRepository
        {
            // Adds a new product to the repository asynchronously
            Task AddProduct(Product product);

            // Retrieves a list of all products from the repository asynchronously
            Task<List<Product>> GetAllProducts();

            // Retrieves a specific product by its ProductId asynchronously
            Task<Product> GetProductById(Guid ProductId);

            // Updates an existing product in the repository asynchronously
            Task Update(Product product);

            // Deletes a product from the repository by its ProductId asynchronously
            Task Delete(Guid ProductId);
        }
}


