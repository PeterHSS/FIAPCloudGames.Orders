namespace FIAPCloudGames.Orders.Api.Commom.Exceptions;

public class OrderNotFoundException(Guid orderId) : Exception($"Order with id '{orderId}' not found.") { }