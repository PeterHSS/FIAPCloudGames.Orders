using FIAPCloudGames.Orders.Api.Features.Repositories;

namespace FIAPCloudGames.Orders.Api.Features.Commands.Delete;

public class DeleteOrderUseCase(IOrderRepository orderRepository)
{
    public async Task HandleAsync(Guid orderId, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetByIdAsync(orderId);

        if (order is null)
            throw new Exception("Order not found.");

        orderRepository.Delete(order);
    }
}
