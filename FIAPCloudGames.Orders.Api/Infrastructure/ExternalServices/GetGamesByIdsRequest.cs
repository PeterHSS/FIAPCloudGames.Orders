namespace FIAPCloudGames.Orders.Api.Infrastructure.ExternalServices;

public sealed record GetGamesByIdsRequest(IEnumerable<Guid> GamesIds);
