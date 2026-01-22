using FIAPCloudGames.Orders.Api.Features.Models;
using Microsoft.EntityFrameworkCore;

namespace FIAPCloudGames.Orders.Api.Infrastructure.Persistence.Context;

public sealed class OrderDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    
    public OrderDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("orders");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderDbContext).Assembly);
    }
}
