using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationWeb.Client.Controllers
{
    /// <summary>
    /// Controller for HomePage.
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index", "~/Views/Shared/_LayoutNoSidebar.cshtml");
        }
    }
}