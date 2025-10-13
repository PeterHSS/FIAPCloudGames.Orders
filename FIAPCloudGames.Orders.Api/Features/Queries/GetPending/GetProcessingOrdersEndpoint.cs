using Carter;
using FIAPCloudGames.Orders.Api.Commom;

namespace FIAPCloudGames.Orders.Api.Features.Queries.GetPending;

public class GetProcessingOrdersEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/processing", async (GetProcessingOrdersUseCase useCase, CancellationToken cancellationToken) =>
        {
            IEnumerable<GetProcessingOrdersResponse> response = await useCase.HandleAsync(cancellationToken);

            return Results.Ok(response);
        })
        .WithTags(Tags.Orders);
    }
}
