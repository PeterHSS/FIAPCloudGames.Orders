using FIAPCloudGames.Orders.Api.Commom.Interfaces;
using FIAPCloudGames.Orders.Api.Features.Queries;

namespace FIAPCloudGames.Orders.Api.Infrastructure.ExternalServices;

public class GameService(HttpClient httpClient) : IGameService
{
    public async Task<IEnumerable<GameResponse>> GetGameListByIds(IEnumerable<Guid> gamesIds)
    {

        HttpResponseMessage response = await httpClient.PostAsJsonAsync("games/by-id", gamesIds);

        return await response.Content.ReadFromJsonAsync<IEnumerable<GameResponse>>()
            ?? [];
    }
}
