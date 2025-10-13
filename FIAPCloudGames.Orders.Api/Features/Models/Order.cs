namespace FIAPCloudGames.Orders.Api.Features.Models;

public sealed class Order
{
    private Order(Guid id, DateTime createdAt, Guid userId, OrderStatus status, decimal totalAmount)
    {
        Id = id;
        CreatedAt = createdAt;
        UserId = userId;
        Status = status;
        TotalAmount = totalAmount;
    }

    private Order() { }


    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Guid UserId { get; private set; }
    public ICollection<OrderItem> Items { get; private set; }
    public OrderStatus Status { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public decimal TotalAmount { get; private set; }

    public static Order Create(Guid userId, decimal totalAmount)
    => new(Guid.NewGuid(), DateTime.UtcNow, userId, OrderStatus.Processing, totalAmount);

    public void ApplyItems(ICollection<OrderItem> items) => Items = items;

    public void ChangeStatus(OrderStatus status)
    {
        Status = status;
        UpdatedAt = DateTime.UtcNow;
    }
}

