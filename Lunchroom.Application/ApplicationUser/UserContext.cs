using Microsoft.AspNetCore.Http;
using System.Security.Claims;


namespace Lunchroom.Application.ApplicationUser
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }

    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public CurrentUser? GetCurrentUser()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user == null)
            {
                throw new InvalidOperationException();
            }

            if (user.Identity == null || !user.Identity.IsAuthenticated)
            {
                return null;
            }

            var id = user.FindFirst(u => u.Type == ClaimTypes.NameIdentifier)?.Value;
            var email = user.FindFirst(u => u.Type == ClaimTypes.Email)?.Value;
            var roles = user.Claims.Where(u => u.Type == ClaimTypes.Role).Select(u => u.Value);

            var currentUser = new CurrentUser(id, email, roles);

            return currentUser;
        }
    }
}