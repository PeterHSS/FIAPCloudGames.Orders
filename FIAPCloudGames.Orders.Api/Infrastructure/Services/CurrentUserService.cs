using System.Security.Claims;
using FIAPCloudGames.Orders.Api.Commom;
using FIAPCloudGames.Orders.Api.Commom.Interfaces;

namespace FIAPCloudGames.Orders.Api.Infrastructure.Services;

public class CurrentUserService(IHttpContextAccessor contextAccessor) : ICurrentUserService
{
    public Guid UserId
        => Guid.TryParse(contextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid id)
            ? id
            : throw new InvalidOperationException("User ID not found in the current context.");
    public bool IsAdmin
    {
        get
        {
            var role = contextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.Role)?.Value;

            if (string.IsNullOrEmpty(role))
                return false;

            return role == Roles.Administrator;
        }
    }
}
