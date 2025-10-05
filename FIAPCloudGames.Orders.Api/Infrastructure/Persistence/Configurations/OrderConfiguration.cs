using FIAPCloudGames.Orders.Api.Features.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAPCloudGames.Orders.Api.Infrastructure.Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{

    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(promotion => promotion.Id).HasName("PK_Orders");

        builder.Property(promotion => promotion.Id).IsRequired();

        builder.Property(promotion => promotion.CreatedAt).IsRequired();

        builder.Property(promotion => promotion.UserId).IsRequired();

        builder.Property(promotion => promotion.TotalAmount).IsRequired().HasPrecision(10, 2);

        builder.Property(promotion => promotion.Status).IsRequired();

        builder.Property(promotion => promotion.UpdatedAt);

        builder.HasIndex(promotion => promotion.UserId).HasDatabaseName("IX_Orders_UserId");

        builder.HasMany(order => order.Items)
            .WithOne()
            .HasForeignKey(item => item.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(order => order.Items).AutoInclude();
    }
}
