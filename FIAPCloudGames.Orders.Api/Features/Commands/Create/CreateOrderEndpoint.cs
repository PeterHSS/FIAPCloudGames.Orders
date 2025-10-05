using Carter;
using FIAPCloudGames.Orders.Api.Commom;

namespace FIAPCloudGames.Orders.Api.Features.Commands.Create;

public class CreateOrderEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/orders",
            async (CreateOrderRequest request, CreateOrderUseCase useCase, CancellationToken cancellationToken) =>
            {
                await useCase.HandleAsync(request);

                return Results.Created();
            })
            .WithTags(Tags.Orders);
    }
}
