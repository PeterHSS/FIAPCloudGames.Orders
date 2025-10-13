namespace FIAPCloudGames.Orders.Api.Commom.Exceptions;

public sealed class ForbiddenUpdateOrderStatusException() : Exception("Only admins can update the order status of other users.") { }