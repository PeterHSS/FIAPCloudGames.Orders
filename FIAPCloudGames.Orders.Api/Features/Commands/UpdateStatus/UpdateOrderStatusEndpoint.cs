using Carter;
using FIAPCloudGames.Orders.Api.Commom;
using FIAPCloudGames.Orders.Api.Features.Commands.Update;

namespace FIAPCloudGames.Orders.Api.Features.Commands.UpdateStatus;

public class UpdateOrderStatusEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/orders/{orderId:guid}/status",
            async (Guid orderId, UpdateOrderStatusRequest request, UpdateOrderStatusUseCase useCase, CancellationToken cancellationToken) =>
            {
                await useCase.HandleAsync(orderId, request, cancellationToken);

                return Results.NoContent();
            })
            .WithTags(Tags.Orders);
    }
}
