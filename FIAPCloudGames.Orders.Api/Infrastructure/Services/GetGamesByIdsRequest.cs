namespace FIAPCloudGames.Orders.Api.Infrastructure.Services;

public sealed record GetGamesByIdsRequest(IEnumerable<Guid> GamesIds);
