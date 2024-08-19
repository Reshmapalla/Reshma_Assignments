using JeansAppAPI.Entities;

namespace JeansAppAPI.Repository
{
    public interface IOrderitemRepository
    {
        Task<List<OrderItems>> GetAll();

        Task<OrderItems> GetOrderitemById(Guid OrderItemId);

        Task AddOrderItems(OrderItems orderItems);
    }
}
