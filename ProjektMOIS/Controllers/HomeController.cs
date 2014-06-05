using ProjektMOIS.DAO;
using ProjektMOIS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektMOIS.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.User = User.Identity.Name;

            return View();
        }

    }
}
