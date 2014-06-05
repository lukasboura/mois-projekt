using ProjektMOIS.DAO;
using ProjektMOIS.Model;
using ProjektMOIS.Model.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektMOIS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CompetitionController : Controller
    {
        private ICompetitionDAO compdao = new CompetitionDAO();
        private IListItems listItems = new MyListItems();
        //
        // GET: /Competetion/

        public ActionResult Index()
        {
            IList<Competition> competitions = compdao.GetAll();
            ViewBag.Competitions = competitions;
            return View();
        }

        //
        // GET: /Competetion/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Competetion/Create

        public ActionResult Create()
        {
            ViewBag.TeamItems = listItems.TeamsOnly();

            return View();
        }

        //
        // POST: /Competetion/Create

        [HttpPost]
        public ActionResult Create(Competition competition)
        {
            try
            {
                if (competition.Team.Id == null)
                {
                    competition.Team = null;
                }
                compdao.Create(competition);
                // TODO: Add insert logic here

                return RedirectToAction("Index", "Competition");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Competetion/Edit/5

        public ActionResult Edit(int id)
        {
            Competition competition = compdao.GetById(id);
            ViewBag.TeamItems = listItems.TeamsOnly();

            return View(competition);
        }

        //
        // POST: /Competetion/Edit/5

        [HttpPost]
        public ActionResult Edit(Competition competition)
        {
            try
            {
                if (competition.Team.Id == null)
                {
                    competition.Team = null;
                }
                compdao.Update(competition);
                return RedirectToAction("Index", "Competition");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Competetion/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Competetion/Delete/5

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
