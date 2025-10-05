using FIAPCloudGames.Orders.Api.Commom.Exceptions;
using FIAPCloudGames.Orders.Api.Features.Repositories;

namespace FIAPCloudGames.Orders.Api.Features.Commands.Update;

public class UpdateOrderStatusUseCase(IOrderRepository orderRepository)
{
    public async Task HandleAsync(Guid orderId, UpdateOrderStatusRequest request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetByIdAsync(orderId, cancellationToken) 
            ?? throw new OrderNotFoundException(orderId);

        order.Status = request.Status;

        order.UpdatedAt = DateTime.UtcNow;

        orderRepository.Update(order);
    }
}