using System.Data;

namespace FIAPCloudGames.Orders.Api.Commom.Interfaces;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
    IDbTransaction BeginTransaction(CancellationToken cancellationToken = default);
}
