using Carter;
using FIAPCloudGames.Orders.Api.Commom;

namespace FIAPCloudGames.Orders.Api.Features.Queries.GetByUserId;

public class GetOrdersByUserIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/user/{userId:guid}",
            async (Guid userId, GetOrdersByUserIdUseCase useCase, CancellationToken cancellationToken) =>
            {
                var orders = await useCase.HandleAsync(userId, cancellationToken);
                
                return Results.Ok(orders);
            })
            .WithTags(Tags.Orders);
    }
}
