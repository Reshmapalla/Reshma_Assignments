using JeansAppAPI.Entities;
using JeansAppAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace JeansAppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        private readonly ITransactionRepository _transactionRepository; // Repository for transaction operations
       

        public TransactionController(ITransactionRepository transactionRepository)
        {
            try
            { 
      
                _transactionRepository = transactionRepository; // Initialize repository
               
            }
            catch (Exception ex)
            {
                // Handle constructor exceptions
                Console.WriteLine(ex.ToString());
            }
        }
        [Authorize(Roles = "Admin,Customer")]
        [HttpGet, Route("GetTransactionByDate/{date}")]
        public async Task<IActionResult> Get([FromRoute] DateTime date)
        {
            try
            {
                // Fetch a transaction by date
                var transaction = await _transactionRepository.GetTransactionByDate(date);
                if (transaction != null)
                {
                    return StatusCode(200, transaction); // Return transaction if found
                }
                else
                {
                    return StatusCode(404, "Invalid Id"); // Return 404 if not found
                }
            }
            catch (Exception ex)
            {
                // Handle method exceptions
                return BadRequest(ex.ToString());
            }
        }
        [Authorize(Roles = "Admin,Customer")]
        [HttpGet, Route("GetTransactionById/{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            try
            {
                // Fetch transactions by user ID
                var transactions = await _transactionRepository.GetTransactionById(id);
                if (transactions != null)
                {
                    return StatusCode(200, transactions); // Return transactions if found
                }
                else
                {
                    return StatusCode(404, "Invalid Id"); // Return 404 if not found
                }
            }
            catch (Exception ex)
            {
                // Handle method exceptions
                return BadRequest(ex.ToString());
            }
        }
        [Authorize(Roles = "Admin,Customer")]
        [HttpPost, Route("AddTransaction")]
        public async Task<IActionResult> Add([FromBody] Transaction transaction)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    transaction.TransactionId = Guid.NewGuid(); // Generate new transaction ID
                    await _transactionRepository.AddTransaction(transaction); // Add the transaction
                    return StatusCode(200, transaction); // Return the added transaction
                }
                else
                {
                    return BadRequest("Enter Valid Details!"); // Return 400 if model state is invalid
                }
            }
            catch (Exception ex)
            {
                // Handle method exceptions
                return BadRequest(ex.ToString());
            }
        }
    }
}

