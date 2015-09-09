﻿using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;
using Miam.DataLayer;
using Miam.Web.Mappers;
using WebApplication1;

namespace Miam.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // C'est dans NinjectWebCommon.cs que la dépendance est gérée
            var dbInitializer = DependencyResolver.Current.GetService<IApplicationDatabase>();
            dbInitializer.MigrateDatabaseToLatestVersion();

            AutoMapperConfiguration.Configure();

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
        }
    }
}
