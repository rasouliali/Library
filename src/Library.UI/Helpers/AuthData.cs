using Library.Application.Dto;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace Library.UI.Helpers
{
    public class AuthData
    {
        public static async Task DeleteLogoutAsync(HttpContext httpContext)
        {
            await httpContext.SignOutAsync();
        }
        public static UserLoginDto GetUserData(HttpContext httpContext)
        {
            UserLoginDto userLogin = new UserLoginDto();
            userLogin.UserName = httpContext.User.FindFirstValue(ClaimTypes.Name);
            userLogin.Roles = httpContext.User.FindFirstValue(ClaimTypes.Role);
            userLogin.ExpireDateTime = DateTime.Parse(httpContext.User.FindFirstValue("Expire"));
            userLogin.FullName = httpContext.User.FindFirstValue("CustomName");
            userLogin.Token = httpContext.User.FindFirstValue("Token");
            userLogin.UserId = int.Parse(httpContext.User.FindFirstValue("UserId"));
            return userLogin;
        }

        internal static async Task SetSignedInAsync(UserLoginDto userLogin, HttpContext httpContext, bool? rememberMe)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name,userLogin.UserName),
            new Claim(ClaimTypes.Role,userLogin.Roles),
            new Claim("Expire",userLogin.ExpireDateTime.ToString()),
            new Claim("CustomName",userLogin.FullName),
            new Claim("Token",userLogin.Token),
            new Claim("UserId",userLogin.UserId+""),
        };
            var claimIdentity = new ClaimsIdentity(claims, "id card");
            var claimPrinciple = new ClaimsPrincipal(claimIdentity);
            var authenticationProperty = new AuthenticationProperties
            {
                IsPersistent = rememberMe??false
            };
            await httpContext.SignInAsync(claimPrinciple, authenticationProperty);


        }
    }
}
