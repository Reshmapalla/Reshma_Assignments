using JeansAppAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JeansAppAPI.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly JeansStationDBContext _context; // Database context
        private readonly IConfiguration _configuration; // Configuration settings

        public TransactionRepository(JeansStationDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task AddTransaction(Transaction transaction)
        {
            try
            {
                // Add a new transaction
                await _context.Transactions.AddAsync(transaction);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new Exception($"Error adding transaction: {ex.Message}", ex);
            }
        }

        public async Task<Transaction> GetTransactionByDate(DateTime date)
        {
            try
            {
                // Fetch a transaction by date
                var transaction = await _context.Transactions
            .FirstOrDefaultAsync(t => t.TransactionDate.Date == date.Date);
                return transaction;
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new Exception($"Error fetching transaction by date: {ex.Message}", ex);
            }
        }

        public async Task<List<Transaction>> GetTransactionById(string id)
        {
            try
            {
                // Fetch transactions by user ID
                var transactions = await _context.Transactions
                    .Where(t => t.UserId == id)
                    .ToListAsync();
                return transactions;
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new Exception($"Error fetching transactions by ID: {ex.Message}", ex);
            }
        }
    }
}

