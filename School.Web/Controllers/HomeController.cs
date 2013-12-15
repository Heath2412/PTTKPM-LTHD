using School.BLL;
using School.BLL.DomainModel;
using School.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace School.Web.Controllers
{
    public class HomeController : Controller
    {
        IService service;
        public HomeController(IService service)
        {
            this.service = service;
        }
        public ActionResult Index()
        {
            ViewBag.a = WebSecurity.IsAuthenticated;
            return View();
        }

    }
}
