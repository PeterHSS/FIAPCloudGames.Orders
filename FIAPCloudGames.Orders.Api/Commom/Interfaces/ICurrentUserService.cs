namespace FIAPCloudGames.Orders.Api.Commom.Interfaces;

public interface ICurrentUserService
{
    Guid UserId { get; }
    bool IsAdmin { get; }
}
