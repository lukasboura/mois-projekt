using ProjektMOIS.DAO;
using ProjektMOIS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektMOIS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SeasonController : Controller
    {
        private ISeasonDAO seasondao = new SeasonDAO();

        //
        // GET: /Season/

        public ActionResult Index()
        {
            IList<Season> seasons = seasondao.GetAll();
            ViewBag.Seasons = seasons;
            return View();
        }

        //
        // GET: /Season/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Season/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Season/Create

        [HttpPost]
        public ActionResult Create(Season season)
        {
            try
            {
                seasondao.Create(season);

                return RedirectToAction("Index", "Season");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Season/Edit/5

        public ActionResult Edit(int id)
        {
            return View(seasondao.GetById(id));
        }

        //
        // POST: /Season/Edit/5

        [HttpPost]
        public ActionResult Edit(Season season)
        {
            try
            {
                seasondao.Update(season);

                return RedirectToAction("Index", "Season");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Season/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Season/Delete/5

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
