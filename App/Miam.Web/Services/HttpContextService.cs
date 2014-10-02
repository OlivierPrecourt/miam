using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Miam.DataLayer;
using Miam.Domain.Entities;
using Miam.Web.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;


namespace Miam.Web.Services
{
    public class HttpContextService : IHttpContextService
    {
        public int GetUserId()
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();

            return int.Parse(userId);
        }

        public void AuthenticationSignIn(ClaimsIdentity identity)
        {
            HttpContext.Current.GetOwinContext().Authentication.SignIn(new AuthenticationProperties(), identity);
        }

        public void AuthenticationSignOut()
        {
            HttpContext.Current.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}