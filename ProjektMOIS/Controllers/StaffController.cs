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
    public class StaffController : Controller
    {
        private IStaffDAO staffdao = new StaffDAO();
        private ITeamStaffDAO teamstaffdao = new TeamStaffDAO();
        private IListItems listItems = new MyListItems();

        //
        // GET: /Staff/

        public ActionResult Index()
        {
            IList<Staff> staffs = staffdao.GetAll();
            ViewBag.Staffs = staffs;
            return View();
        }

        public ActionResult EditRoles(int id)
        {
            Staff staff = staffdao.GetById(id);
            ViewBag.Staff = staff;
            return View();
        }

        //
        // GET: /Staff/Details/5

        public ActionResult Details(int id)
        {
            Staff staff = staffdao.GetById(id);
            ViewBag.Staff = staff;
            return View();
        }

        //
        // GET: /Staff/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.Countries = listItems.Countries();
            return View();
        }

        //
        // POST: /Staff/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Staff staff)
        {
            if (ModelState.IsValid)
            {
                staff.Photo = ImageHelper.GetDefault();
                staffdao.Create(staff);
                return RedirectToAction("Index", "Staff");
            }
            else
            {
                ViewBag.Countries = listItems.Countries();
                return View(staff);
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult CreateRole(int id)
        {
            ViewBag.Teams = listItems.TeamsOnly();
            StaffRoleViewModel model = new StaffRoleViewModel();
            model.Staff = id;
            ViewBag.Staff = staffdao.GetById(id);
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult EditRole(int id)
        {
            ViewBag.Teams = listItems.TeamsOnly();
            TeamStaff ts = teamstaffdao.GetById(id);
            StaffRoleViewModel model = new StaffRoleViewModel();
            model.Role = ts.Role;
            model.Staff = ts.Staff.Id;
            model.Team = ts.Team.Id;
            ViewBag.ID = id;
            return View(model);
        }

        //
        // POST: /Staff/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult CreateRole(int id, StaffRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                TeamStaff teamstaff = new TeamStaff
                {
                    Id = id,
                    Team = new Team { Id = model.Team },
                    Staff = new Staff { Id = model.Staff },
                    Role = model.Role
                };
                teamstaffdao.Create(teamstaff);
                return RedirectToAction("EditRoles", "Staff", new { Id = teamstaff.Staff.Id });
            }
            else
            {
                ViewBag.Teams = listItems.TeamsOnly();
                ViewBag.Staff = staffdao.GetById(id);
                return View(model);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditRole(int id, StaffRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                TeamStaff teamstaff = new TeamStaff
                {
                    Id = id,
                    Team = new Team { Id = model.Team},
                    Staff = new Staff { Id = model.Staff },
                    Role = model.Role
                };

                teamstaffdao.Update(teamstaff);
                return RedirectToAction("EditRoles", "Staff", new { Id = teamstaff.Staff.Id });
            }
            else
            {
                ViewBag.Teams = listItems.TeamsOnly();
                ViewBag.ID = id;
                return View(model);
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteRole(int id)
        {
            try
            {
                TeamStaff ts = teamstaffdao.GetById(id);
                teamstaffdao.Delete(ts);

                return RedirectToAction("EditRoles", "Staff", new { id = ts.Staff.Id });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Staff/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Staff staff = staffdao.GetById(id);
            ViewBag.Countries = listItems.Countries();
            return View(staff);
        }

        //
        // POST: /Staff/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(Staff staff, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    staff.Photo = ImageHelper.Thumbnail(file);
                }
                staffdao.Update(staff);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Countries = listItems.Countries();
                return View(staff);
            }
        }

        //
        // GET: /Staff/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Staff/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
