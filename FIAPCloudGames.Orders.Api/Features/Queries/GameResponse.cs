namespace FIAPCloudGames.Orders.Api.Features.Queries;

public record GameResponse(Guid Id, string Name, string Description, DateTime ReleasedAt, decimal Price, string Genre);
