using FIAPCloudGames.Orders.Api.Features.Models;

namespace FIAPCloudGames.Orders.Api.Features.Queries.GetPending;

public record GetProcessingOrdersResponse(Guid OrderId)
{
    public static GetProcessingOrdersResponse Create(Order order) => new(order.Id);
};
