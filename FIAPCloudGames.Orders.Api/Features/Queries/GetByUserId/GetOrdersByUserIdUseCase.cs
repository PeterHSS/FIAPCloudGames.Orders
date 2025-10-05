using FIAPCloudGames.Orders.Api.Commom.Interfaces;
using FIAPCloudGames.Orders.Api.Features.Repositories;

namespace FIAPCloudGames.Orders.Api.Features.Queries.GetByUserId;

public class GetOrdersByUserIdUseCase(IOrderRepository repository, IGameService gameService)
{
    public async Task<IEnumerable<OrderResponse>> HandleAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var orders = await repository.GetByUserIdAsync(userId, cancellationToken);

        if (orders is null || !orders.Any())
            return [];

        var ordersGameIds = orders.SelectMany(o => o.Items).Select(i => i.GameId).Distinct();

        var games = await gameService.GetGameListByIds(ordersGameIds);

        var ordersResponse = orders.Select(o => OrderResponse.Create(o, games.Where(g => o.Items.Any(i => i.GameId == g.Id))));

        return ordersResponse;
    }
}
