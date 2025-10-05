using FIAPCloudGames.Orders.Api.Commom.Interfaces;
using FIAPCloudGames.Orders.Api.Features.Models;
using FIAPCloudGames.Orders.Api.Features.Repositories;

namespace FIAPCloudGames.Orders.Api.Features.Commands.Create;

public class CreateOrderUseCase(IGameService gameServcice, IOrderRepository orderRepository)
{
    public async Task HandleAsync(CreateOrderRequest request)
    {
        var games = await gameServcice.GetGameListByIds(request.GamesId);

        if (!games.Any())
            throw new Exception("No games found for the provided IDs.");

        var order = new Order
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            UserId = request.UserId,
            TotalAmount = games.Sum(g => g.Price),
        };

        var orderItems = games.Select(game => new OrderItem(Guid.NewGuid(), order.Id, game.Id, game.Price)).ToList();

        order.Items = orderItems;

        await orderRepository.AddAsync(order);
    }
}
