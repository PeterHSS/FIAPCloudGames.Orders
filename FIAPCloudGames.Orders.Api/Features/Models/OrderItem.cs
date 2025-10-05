namespace FIAPCloudGames.Orders.Api.Features.Models;

public record OrderItem(Guid Id, Guid OrderId, Guid GameId, decimal Price);
