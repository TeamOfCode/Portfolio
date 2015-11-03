﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Nieruchomosci.Binding;
using Nieruchomosci.Models;
using WebMatrix.WebData;

namespace Nieruchomosci
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {


            //   WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);



            ClientDataTypeModelValidatorProvider.ResourceClassKey = "MyResources";

            DefaultModelBinder.ResourceClassKey = "MyResources";

            AreaRegistration.RegisterAllAreas();

            ModelBinders.Binders.Add(typeof (ViewModelFiltrowanieOgloszenie), new NIeruchmosciModelBinder());

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }
    }
}