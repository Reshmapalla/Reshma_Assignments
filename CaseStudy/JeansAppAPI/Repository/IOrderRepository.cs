using JeansAppAPI.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeansAppAPI.Repository
{
    public interface IOrderRepository
    {
        Task Add(Order order); // Adds a new Order to the database asynchronously.
        Task<Order> GetOrderById(Guid orderId); // Retrieves an Order by its ID asynchronously.
        Task<List<Order>>GetAllOrders(); // Retrieves all Orders from the database asynchronously.
        Task Delete(Guid id); // Deletes an Order by its ID asynchronously.
    }
}

