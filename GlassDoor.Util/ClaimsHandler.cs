using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Principal;

namespace GlassDoor.Util
{
    public static class ClaimsHandler
    {
        public static int GetUserId(this IIdentity principal)
        {
            var claims = principal as ClaimsIdentity;

            int userId;

            var preParseUserID = claims.FindFirst(ClaimTypes.Sid)?.Value;

            if (int.TryParse(preParseUserID, out userId))
                return userId;

            return -1;
        }

        public static async Task ReAuthenticate(this HttpContext _Context, List<Claim> claims)
        {
            if (_Context.User.Identity.IsAuthenticated)
            {
                await _Context.SignOutAsync();
            }

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();

            await _Context.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }
    }
}
