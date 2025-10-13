using FIAPCloudGames.Orders.Api.Features.Models;

namespace FIAPCloudGames.Orders.Api.Features.Repositories;

public interface IOrderRepository
{
    Task AddAsync(Order order, CancellationToken cancellationToken = default);
    Task<Order?> GetByIdAsync(Guid orderId, CancellationToken cancellationToken= default);
    Task<IEnumerable<Order>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Order>> GetPendingOrders(CancellationToken cancellationToken = default, int size = 1000);
    void Delete(Order order);
    void Update(Order order);
}
