using JeansAppAPI.Entities;

namespace JeansAppAPI.Repository
{
    public interface ITransactionRepository
    {
        Task<Transaction> GetTransactionByDate(DateTime date); // Retrieve a transaction by date

        Task<List<Transaction>> GetTransactionById(string id); // Retrieve transactions by ID

        Task AddTransaction(Transaction transaction); // Add a new transaction
    }
}
