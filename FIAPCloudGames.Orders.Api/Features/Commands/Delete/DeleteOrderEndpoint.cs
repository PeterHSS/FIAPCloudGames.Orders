using Carter;
using FIAPCloudGames.Orders.Api.Commom;

namespace FIAPCloudGames.Orders.Api.Features.Commands.Delete;

public class DeleteOrderEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/orders/{orderId:guid}",
            async (Guid orderId, DeleteOrderUseCase useCase, CancellationToken cancellationToken) =>
            {
                await useCase.HandleAsync(orderId, cancellationToken);

                return Results.NoContent();
            })
            .WithTags(Tags.Orders);
    }
}
