using ProjektMOIS.DAO;
using ProjektMOIS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektMOIS.Controllers
{
    public class TeamController : Controller
    {
        private ITeamDAO teamdao = new TeamDAO();
        private IPlayerDAO playerdao = new PlayerDAO();
        private ICompetitionDAO compdao = new CompetitionDAO();
        private IGameDAO gamedao = new GameDAO();
        //
        // GET: /Team/

        public ActionResult Index()
        {
            IList<Team> teams = teamdao.GetAll();

            ViewBag.Teams = teams;
            //ViewBag.Competitions = compdao.GetByTeam(id);
            //ViewBag.Players = playerdao.GetByTeam(id);

            return View();
        }

        //
        // GET: /Team/Details/5

        public ActionResult Details(int id)
        {
            Team team = teamdao.GetById(id);
            ViewBag.Team = team;
            ViewBag.LastGames = gamedao.GetLast(id, 10);
            //ViewBag.Competitions = compdao.GetByTeam(id);
            //ViewBag.Players = playerdao.GetByTeam(id);
            return View();
        }

        //
        // GET: /Team/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Team/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Team team)
        {
            if(ModelState.IsValid)
            {
                teamdao.Create(team);
                return RedirectToAction("Index", "Team");
            }
            else
            {
                return View(team);
            }
        }

        //
        // GET: /Team/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Team team = teamdao.GetById(id);
            return View(team);
        }

        //
        // POST: /Team/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(Team team)
        {
            if(ModelState.IsValid)
            {
                teamdao.Update(team);
                return RedirectToAction("Details", "Team", new { id = team.Id });
            }
            else
            {
                return View(team);
            }
        }

        //
        // GET: /Team/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Team/Delete/5
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
