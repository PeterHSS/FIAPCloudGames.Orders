using FIAPCloudGames.Orders.Api.Features.Models;
using FIAPCloudGames.Orders.Api.Features.Repositories;

namespace FIAPCloudGames.Orders.Api.Features.Queries.GetPending;

public class GetProcessingOrdersUseCase(IOrderRepository repository)
{
    public async Task<IEnumerable<GetProcessingOrdersResponse>> HandleAsync(CancellationToken cancellationToken)
    {
        IEnumerable<Order> pendingOrders = await repository.GetPendingOrders(cancellationToken);

        return pendingOrders.Select(GetProcessingOrdersResponse.Create);
    }
}
