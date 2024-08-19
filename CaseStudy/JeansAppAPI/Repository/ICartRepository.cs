using JeansAppAPI.Entities;

namespace JeansAppAPI.Repository
{
    public interface ICartRepository
    {
       
        Task AddCartItem(CartItem cartitem);

      
        Task<List<CartItem>> GetAllCartItems();

        Task<CartItem> GetCartitemById(Guid CartId);

        
        Task Update(CartItem cartitem);

        
        Task Delete(Guid CartId);
    }
}
