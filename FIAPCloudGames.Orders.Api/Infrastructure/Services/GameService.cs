using FIAPCloudGames.Orders.Api.Commom.Interfaces;
using FIAPCloudGames.Orders.Api.Features.Queries;

namespace FIAPCloudGames.Orders.Api.Infrastructure.Services;

public class GameService(HttpClient httpClient) : IGameService
{
    public async Task<IEnumerable<GameResponse>> GetGameListByIds(IEnumerable<Guid> gamesIds)
    {
        var request = new GetGamesByIdsRequest(gamesIds);

        HttpResponseMessage response = await httpClient.PostAsJsonAsync("/games/by-ids", request);

        return await response.Content.ReadFromJsonAsync<IEnumerable<GameResponse>>()
            ?? [];
    }
}
