using Carter;
using FIAPCloudGames.Orders.Api.Commom;

namespace FIAPCloudGames.Orders.Api.Features.Queries.GetById;

public class GetOrderByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/{orderId:guid}",
            async (Guid orderId, GetOrderByIdUseCase useCase, CancellationToken cancellationToken) =>
            {
                var order = await useCase.HandleAsync(orderId, cancellationToken);

                return Results.Ok(order);
            })
            .WithTags(Tags.Orders);
    }

}
