using FIAPCloudGames.Orders.Api.Features.Models;

namespace FIAPCloudGames.Orders.Api.Features.Queries;

public record OrderResponse(
    Guid Id,
    DateTime CreatedAt,
    Guid UserId,
    IEnumerable<GameResponse> Items,
    OrderStatus Status,
    DateTime UpdatedAt,
    decimal TotalAmount)
{
    public static OrderResponse Create(Order order, IEnumerable<GameResponse> games)
        => new(order.Id, order.CreatedAt, order.UserId, games, order.Status, order.UpdatedAt, order.TotalAmount);
}
