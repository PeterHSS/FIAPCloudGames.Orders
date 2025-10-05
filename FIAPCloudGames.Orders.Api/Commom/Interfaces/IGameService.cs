using FIAPCloudGames.Orders.Api.Features.Queries;

namespace FIAPCloudGames.Orders.Api.Commom.Interfaces;

public interface IGameService
{
    Task<IEnumerable<GameResponse>> GetGameListByIds(IEnumerable<Guid> gamesIds);
}
