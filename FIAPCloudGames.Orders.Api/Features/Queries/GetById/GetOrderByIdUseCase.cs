using FIAPCloudGames.Orders.Api.Commom.Exceptions;
using FIAPCloudGames.Orders.Api.Commom.Interfaces;
using FIAPCloudGames.Orders.Api.Features.Repositories;

namespace FIAPCloudGames.Orders.Api.Features.Queries.GetById;

public class GetOrderByIdUseCase(IOrderRepository orderRepository, IGameService gameService)
{
    public async Task<OrderResponse?> HandleAsync(Guid orderId, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetByIdAsync(orderId, cancellationToken);
        
        if (order is null)
            throw new OrderNotFoundException(orderId);

        var games = await gameService.GetGameListByIds(order.Items.Select(item => item.GameId).ToList());

        return OrderResponse.Create(order, games);
    }
}
