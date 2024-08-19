using JeansAppAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace JeansAppAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly JeansStationDBContext _context;
        // Constructor to inject the DbContext dependency
        public UserRepository(JeansStationDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }



        // Asynchronously retrieves all users from the database
        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                // Asynchronously fetches the list of users from the database
                return await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception to the console
                Console.WriteLine($"An error occurred while fetching users: {ex.Message}");

                // Return an empty list if an error occurs
                return new List<User>();
            }
        }

        // Asynchronously registers a new user in the database
        public async Task Register(User user)
        {
            try
            {
                // Asynchronously adds the user to the DbSet
                await _context.Users.AddAsync(user);

                // Asynchronously saves changes to the database
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception to the console
                Console.WriteLine($"An error occurred while registering the user: {ex.Message}");

                // Optionally handle or rethrow the exception
            }
        }

        // Asynchronously validates a user by email and password
        public async Task<User> ValidUser(string email, string password)
        {
            try
            {
                // Asynchronously fetches the user matching the provided email and password
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

                if (user != null)
                {
                    // Return the user if found
                    return user;
                }
                else
                {
                    // Log the validation failure to the console
                    Console.WriteLine("User validation failed.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Log the exception to the console
                Console.WriteLine($"An error occurred during user validation: {ex.Message}");

                // Return null if an error occurs
                return null;
            }
        }

        // Asynchronously updates an existing user in the database
        public async Task Update(User user)
        {
            try
            {
                // Updates the user entity in the DbSet
                _context.Users.Update(user);

                // Asynchronously saves changes to the database
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception to the console
                Console.WriteLine($"An error occurred while updating the user: {ex.Message}");

                // Optionally handle or rethrow the exception
            }
        }

        // Asynchronously deletes a user by ID from the database
        public async Task Delete(string id)
        {
            try
            {
                // Asynchronously finds the user by ID
                var user = await _context.Users.FindAsync(id);

                if (user != null)
                {
                    // Removes the user from the DbSet
                    _context.Users.Remove(user);

                    // Asynchronously saves changes to the database
                    await _context.SaveChangesAsync();
                }
                else
                {
                    // Log that the user was not found
                    Console.WriteLine("User not found.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception to the console
                Console.WriteLine($"An error occurred while deleting the user: {ex.Message}");

                // Optionally handle or rethrow the exception
            }
        }
    }
}








    

