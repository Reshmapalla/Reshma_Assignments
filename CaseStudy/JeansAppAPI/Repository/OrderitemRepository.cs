using JeansAppAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeansAppAPI.Repository
{
    public class OrderItemRepository : IOrderitemRepository
    {
        private readonly JeansStationDBContext _dbContext;

        public OrderItemRepository(JeansStationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddOrderItems(OrderItems orderItems)
        {
            try
            {
                await _dbContext.OrderItems.AddAsync(orderItems);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<List<OrderItems>> GetAll()
        {
            try
            {
                return await _dbContext.OrderItems.ToListAsync(); // Retrieves all OrderItems asynchronously.
            }
            catch (Exception ex)
            {
                // Log the exception (logging implementation not shown here)
                throw new Exception(ex.Message); // Throws a new exception with a custom message.
            }
        }

        public async Task<OrderItems> GetOrderitemById(Guid OrderItemId)
        {
            try
            {
                var orderItem = await _dbContext.OrderItems.FindAsync(OrderItemId); // Retrieves an OrderItem by its ID asynchronously.
                return orderItem;
            }
            catch (Exception ex)
            {
                // Log the exception (logging implementation not shown here)
                throw new Exception(ex.Message);// Throws a new exception with a custom message.
            }
        }
    }
}
