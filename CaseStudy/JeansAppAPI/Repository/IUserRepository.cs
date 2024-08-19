using JeansAppAPI.Entities;

namespace JeansAppAPI.Repository
{
    public interface IUserRepository
    {
       
            Task Register(User user);
            Task<User> ValidUser(string email, string password);
            Task<List<User>> GetAllUsers();
            Task Delete(string id);
            Task Update(User user);
        


    }
}
