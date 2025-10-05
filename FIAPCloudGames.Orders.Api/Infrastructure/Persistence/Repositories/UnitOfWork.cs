using System.Data;
using FIAPCloudGames.Orders.Api.Commom.Interfaces;
using FIAPCloudGames.Orders.Api.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace FIAPCloudGames.Orders.Api.Infrastructure.Persistence.Repositories;

internal sealed class UnitOfWork(OrderDbContext context) : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default) 
        => await context.SaveChangesAsync(cancellationToken);

    public IDbTransaction BeginTransaction(CancellationToken cancellationToken = default)
    {
        IDbContextTransaction dbContextTransaction = context.Database.BeginTransaction();

        return dbContextTransaction.GetDbTransaction();
    }
}
