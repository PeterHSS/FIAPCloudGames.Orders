using FIAPCloudGames.Orders.Api.Features.Models;

namespace FIAPCloudGames.Orders.Api.Features.Commands.Update;

public record UpdateOrderStatusRequest(OrderStatus Status);
