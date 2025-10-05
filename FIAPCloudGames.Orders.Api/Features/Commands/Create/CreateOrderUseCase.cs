using FIAPCloudGames.Orders.Api.Commom.Interfaces;
using FIAPCloudGames.Orders.Api.Features.Models;
using FIAPCloudGames.Orders.Api.Features.Repositories;

namespace FIAPCloudGames.Orders.Api.Features.Commands.Create;

public class CreateOrderUseCase(IGameService gameServcice, IOrderRepository orderRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        var games = await gameServcice.GetGameListByIds(request.GamesId);

        if (!games.Any())
            throw new Exception("No games found for the provided IDs.");

        var missingGameIds = request.GamesId.Except(games.Select(g => g.Id)).ToList();

        if (missingGameIds.Any())
            throw new Exception($"The following game IDs were not found: {string.Join(", ", missingGameIds)}");

        Order order = Order.Create(request.UserId, games.Sum(game => game.Price));

        List<OrderItem> orderItems = games.Select(game => new OrderItem(Guid.NewGuid(), order.Id, game.Id, game.Price)).ToList();

        order.ApplyItems(orderItems);

        await orderRepository.AddAsync(order);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
