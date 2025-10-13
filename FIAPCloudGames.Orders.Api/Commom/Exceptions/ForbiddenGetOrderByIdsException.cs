namespace FIAPCloudGames.Orders.Api.Commom.Exceptions;

public sealed class ForbiddenGetOrderByIdsException() : Exception("Only admins can get the order of other users.") { }