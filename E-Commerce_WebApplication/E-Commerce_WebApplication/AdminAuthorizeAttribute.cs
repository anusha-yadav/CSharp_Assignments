using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace E_Commerce_WebApplication
{
    public class AdminAuthorizeAttribute : IAuthorizationFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdminAuthorizeAttribute(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            if (!IsUserAdmin(session.GetString("user")))
            {
                context.Result = new RedirectToActionResult("Unauthorized", "Error", null);
            }
        }

        private bool IsUserAdmin(string username)
        {
            List<string> roles = new List<string>
            {
                "admin",
                "admin1"
            };
            return roles.Contains(username);
        }
    }
}
