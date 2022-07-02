using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace HotelBooking.Models
{
    public class MyAuth : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.User.Identity.GetUserId();
        }
    }

    public static class  AuthHelper {

        public static bool GetClaimGender ( this IIdentity identity)
        {
            //var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();

            ////Filter specific claim    
            //claims?.FirstOrDefault(x => x.Type.Equals("Gender", StringComparison.OrdinalIgnoreCase))?.Value;
            //return claims.FirstOrDefault(a=> a.i)
            return false;
        }
    }

}