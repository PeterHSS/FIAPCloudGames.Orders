using FIAPCloudGames.Orders.Api.Commom.Exceptions;
using FIAPCloudGames.Orders.Api.Commom.Interfaces;
using FIAPCloudGames.Orders.Api.Features.Commands.Update;
using FIAPCloudGames.Orders.Api.Features.Repositories;

namespace FIAPCloudGames.Orders.Api.Features.Commands.UpdateStatus;

public class UpdateOrderStatusUseCase(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(Guid orderId, UpdateOrderStatusRequest request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetByIdAsync(orderId, cancellationToken)
            ?? throw new OrderNotFoundException(orderId);

        order.ChangeStatus(request.Status);

        orderRepository.Update(order);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
