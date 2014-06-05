using ProjektMOIS.Model;
using ProjektMOIS.DAO;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ProjektMOIS.Service;
using System.Text;
using MongoDB.Driver;
using ProjektMOIS.Utils;

namespace ProjektMOIS.Controllers
{

    public class LoginController : Controller
    {
        private IUserDAO userdao = new UserDAO();

        //
        // GET: /Login/

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "home");
            }
            return View();
        }

        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();

            return RedirectToAction("index", "login");
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = userdao.GetByEmail(model.Email);

                if (user != null && MD5.Encode(model.Password) == user.Password)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    return RedirectToAction("index", "home");
                }
                {
                    ModelState.AddModelError("", "Invalid email or password");
                }
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult SignUp()
        {
            User user = new User();
            user.Role = "Uživatel";
            return View(user);
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {

            if (ModelState.IsValid)
            {
                if (userdao.GetByEmail(user.Email) != null)
                {
                    ViewData["ErrorMessage"] = "Email already exist.";
                    return View(user);
                }
                user.Password = MD5.Encode(user.Password);
                userdao.Create(user);
                TempData["SuccessMessage"] = "User was successfully signed up.";
                return RedirectToAction("index", "login");
            }
            else
            {
                return View(user);
            }
        }

    }


}
