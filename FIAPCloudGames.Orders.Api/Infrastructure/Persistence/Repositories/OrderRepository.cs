using FIAPCloudGames.Orders.Api.Features.Models;
using FIAPCloudGames.Orders.Api.Features.Repositories;
using FIAPCloudGames.Orders.Api.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FIAPCloudGames.Orders.Api.Infrastructure.Persistence.Repositories;

internal sealed class OrderRepository(OrderDbContext context) : IOrderRepository
{
    public async Task AddAsync(Order order, CancellationToken cancellationToken = default)
        => await context.Orders.AddAsync(order, cancellationToken);

    public void Delete(Order order)
        => context.Orders.Remove(order);

    public async Task<Order?> GetByIdAsync(Guid orderId, CancellationToken cancellationToken = default)
        => await context.Orders.FirstOrDefaultAsync(o => o.Id == orderId, cancellationToken);

    public async Task<IEnumerable<Order>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        => await context.Orders.Where(o => o.UserId == userId).ToListAsync(cancellationToken);

    public async Task<IEnumerable<Order>> GetPendingOrders(CancellationToken cancellationToken = default, int size = 1000)
        => await context.Orders.Where(o => o.Status == OrderStatus.Processing).Take(size).ToListAsync(cancellationToken);

    public void Update(Order order)
        => context.Orders.Update(order);
}
