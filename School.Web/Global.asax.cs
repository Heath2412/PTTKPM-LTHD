using AutoMapper;
using School.BLL.DomainModel;
using School.BLL.Interfaces;
using School.CompositionRoot;
using School.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using WebMatrix.WebData;

namespace School.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            DependencyResolver.SetResolver(new NinjectDependencyResolver());

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            AccountInit();
        }

        private void AccountInit()
        {
            if (!WebSecurity.UserExists("admin"))
            {
                WebSecurity.CreateAccount("admin", "admin", false);
                Roles.AddUserToRole("admin", "Admin");
            }
        }
    }

}