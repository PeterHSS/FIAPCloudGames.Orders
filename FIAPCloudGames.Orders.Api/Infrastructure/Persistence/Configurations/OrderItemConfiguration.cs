using FIAPCloudGames.Orders.Api.Features.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAPCloudGames.Orders.Api.Infrastructure.Persistence.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItems");

        builder.HasKey(orderItem => orderItem.Id).HasName("PK_OrderItems");

        builder.Property(orderItem => orderItem.Id).IsRequired();

        builder.Property(orderItem => orderItem.OrderId).IsRequired();

        builder.Property(orderItem => orderItem.GameId).IsRequired();

        builder.Property(orderItem => orderItem.Price).IsRequired().HasPrecision(10, 2);

        builder.HasOne<Order>()
            .WithMany(order => order.Items)
            .HasForeignKey(orderItem => orderItem.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
