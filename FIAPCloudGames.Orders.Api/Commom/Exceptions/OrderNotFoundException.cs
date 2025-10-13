namespace FIAPCloudGames.Orders.Api.Commom.Exceptions;

public sealed class OrderNotFoundException(Guid orderId) : Exception($"Order with id '{orderId}' not found.") { }