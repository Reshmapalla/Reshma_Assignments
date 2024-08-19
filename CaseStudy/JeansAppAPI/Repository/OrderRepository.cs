using JeansAppAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeansAppAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly JeansStationDBContext _dbContext;

        public OrderRepository(JeansStationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Order order)
        {
            try
            {
                await _dbContext.Orders.AddAsync(order); // Adds a new Order to the database asynchronously.
                await _dbContext.SaveChangesAsync(); // Saves changes to the database asynchronously.
            }
            catch (Exception ex)
            {
                // Log the exception (logging implementation not shown here)
                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.OrderId == id); // Finds the Order by its ID asynchronously.

              
                    _dbContext.Orders.Remove(order); // Removes the Order from the database.
                    await _dbContext.SaveChangesAsync(); // Saves changes to the database asynchronously.
                
                
            }
            catch (Exception ex)
            {
                // Log the exception (logging implementation not shown here)
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Order>> GetAllOrders()
        {
            try
            {
                return await _dbContext.Orders.ToListAsync(); // Retrieves all Orders from the database asynchronously.
            }
            catch (Exception ex)
            {
                // Log the exception (logging implementation not shown here)
                throw new Exception(ex.Message);
            }
        }

        public async Task<Order> GetOrderById(Guid orderId)
        {
            try
            {
                var order = await _dbContext.Orders.FindAsync(orderId); // Retrieves the Order by its ID asynchronously.
                return order;
            }
            catch (Exception ex)
            {
                // Log the exception (logging implementation not shown here)
                throw new Exception(ex.Message);
            }
        }
    }
}

