namespace FIAPCloudGames.Orders.Api.Features.Models;

public sealed class Order
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid UserId { get; set; }
    public ICollection<OrderItem> Items { get; set; } = [];
    public OrderStatus Status { get; set; } 
    public DateTime UpdatedAt { get; set; }
    public decimal TotalAmount { get; set; }
}
