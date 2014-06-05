using ProjektMOIS.DAO;
using ProjektMOIS.Model;
using ProjektMOIS.Model.Others;
using ProjektMOIS.Model.ViewModels;
using ProjektMOIS.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektMOIS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private IUserDAO userdao = new UserDAO();
        private IListItems items = new MyListItems();
        //
        // GET: /Users/

        public ActionResult Index()
        {
            ViewBag.Users = userdao.GetAll();
            return View();
        }

        //
        // GET: /Users/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Users/Create

        public ActionResult Create()
        {
            ViewBag.RoleItems = items.Roles();
            return View();
        }

        //
        // POST: /Users/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            if(ModelState.IsValid)
            {
                user.Password = MD5.Encode(user.Password);
                userdao.Create(user);

                return RedirectToAction("Index", "Users");
            }
            else
            {
                ViewBag.RoleItems = items.Roles();
                return View(user);
            }
        }

        //
        // GET: /Users/Edit/5

        public ActionResult Edit(int id)
        {
            ViewBag.RoleItems = items.Roles();
            User user = userdao.GetById(id);
            EditUserViewModel model = new EditUserViewModel(user);
            return View(model);
        }

        //
        // POST: /Users/Edit/5

        [HttpPost]
        public ActionResult Edit(EditUserViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                userdao.Update(userVM.ToUser());
                TempData["SuccessMessage"] = "Profil uživatele byl úspěšně upraven.";
                return RedirectToAction("Index", "Users");
            }
            else
            {
                ViewBag.RoleItems = items.Roles();
                return View(userVM);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                userdao.Delete(userdao.GetById(id));

                return RedirectToAction("Index", "Users");
            }
            catch
            {
                return RedirectToAction("Index", "Users");
            }
        }
    }
}
