using JeansAppAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace JeansAppAPI.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly JeansStationDBContext _context;

        public CartRepository(JeansStationDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); // Initialize the database context
        }

        public async Task AddCartItem(CartItem cartitem)
        {
            try
            {
                await _context.CartItems.AddAsync(cartitem); // Add a new cart item to the database
                await _context.SaveChangesAsync(); // Save changes to the database
            }
            catch (Exception ex)
            {
                // Handle exceptions that may occur during the add operation
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<CartItem>> GetAllCartItems()
        {
            try
            {
                return await _context.CartItems.ToListAsync(); // Retrieve all cart items from the database
            }
            catch (Exception ex)
            {
                // Handle exceptions that may occur during the retrieval operation
                throw new Exception(ex.Message);
            }
        }

        public async Task<CartItem> GetCartitemById(Guid CartId)
        {
            try
            {
                var cartItem = await _context.CartItems.FindAsync(CartId); // Retrieve a cart item by its ID
                
                return cartItem;
            }
            catch (Exception ex)
            {
                // Handle exceptions that may occur during the retrieval operation
                throw new Exception(ex.Message);
            }
        }

        public async Task Update(CartItem cartitem)
        {
            try
            {
                _context.CartItems.Update(cartitem); // Update the cart item in the database
                await _context.SaveChangesAsync(); // Save changes to the database
            }
            catch (Exception ex)
            {
                // Handle exceptions that may occur during the update operation
                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(Guid CartId)
        {
            try
            {
                var cartItem = await _context.CartItems.FindAsync(CartId); // Find the cart item by its ID
               
                _context.CartItems.Remove(cartItem); // Remove the cart item from the database
                await _context.SaveChangesAsync(); // Save changes to the database
            }
            catch (Exception ex)
            {
                // Handle exceptions that may occur during the delete operation
                throw new Exception(ex.Message);
            }
        }
    }
}

