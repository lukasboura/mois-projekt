using ProjektMOIS.DAO;
using ProjektMOIS.Model;
using ProjektMOIS.Model.Others;
using ProjektMOIS.Model.ViewModels;
using ProjektMOIS.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ProjektMOIS.Controllers
{
    public class PlayerController : Controller
    {

        private ITeamDAO teamdao = new TeamDAO();
        private IPlayerDAO playerdao = new PlayerDAO();
        private IPlayerStatsDAO psdao = new PlayerStatsDAO();
        private IListItems listItems = new MyListItems();
        //
        // GET: /Player/

        public ActionResult Index()
        {
            IList<Team> teams = teamdao.GetAll();

            return RedirectToAction("Team", "Player", new { id = teams.First().Id });
        }

        public ActionResult Inactive()
        {
            IList<Team> teams = teamdao.GetAll();
            IList<Player> players = playerdao.GetByActive(false);
            ViewBag.Players = players;
            ViewBag.Teams = teams;
            return View();
        }

        //
        // GET: /Player/Team/5

        public ActionResult Team(int id)
        {
            IList<Team> teams = teamdao.GetAll();
            IList<Player> players = playerdao.GetByTeam(id);

            ViewBag.Teams = teams;
            ViewBag.Players = players;
            ViewBag.id = id;
            return View();
        }

        //
        // GET: /Player/Details/5

        public ActionResult Details(int id)
        {
            Player player = playerdao.GetById(id);
            IList<ProjektMOIS.DAO.PlayerStatsDAO.HistoryData> res = psdao.GroupTest(id);
            ViewBag.History = res;
            ViewBag.Player = player;
            ViewBag.Stats = psdao.GetLastStats(id, 5);
            return View();
        }

        //
        // GET: /Player/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.TeamItems = listItems.Teams();
            ViewBag.PositionItems = listItems.Positions();

            ViewData["Countries"] = listItems.Countries();
            return View();
        }

        //
        // POST: /Player/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(PlayerViewModel playerVM)
        {
            playerVM.Active = true;
            if (ModelState.IsValid)
            {
                playerVM.Photo = ImageHelper.GetDefault();
                playerdao.Create(playerVM.ToPlayer());

                return RedirectToAction("Team", "Player", new { id = playerVM.Team });
            }
            else 
            {
                ViewBag.TeamItems = listItems.Teams();
                ViewBag.PositionItems = listItems.Positions();
                ViewData["Countries"] = listItems.Countries();
                return View(playerVM);
            }
        }

        //
        // GET: /Player/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Player player = playerdao.GetById(id);

            ViewBag.Player = player;
            ViewBag.TeamItems = listItems.Teams();
            ViewBag.PositionItems = listItems.Positions();
            ViewData["Countries"] = listItems.Countries();

            return View(new PlayerViewModel(player));
        }

        //
        // POST: /Player/Edit
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(PlayerViewModel playerVM, HttpPostedFileBase file)
        {           
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    playerVM.Photo = ImageHelper.Thumbnail(file);
                }
                playerdao.Update(playerVM.ToPlayer());
                return RedirectToAction("Team", "Player", new { id = playerVM.Team });
            }
            else
            {
                ViewBag.Player = playerVM;
                ViewBag.TeamItems = listItems.Teams();
                ViewBag.PositionItems = listItems.Positions();
                ViewData["Countries"] = listItems.Countries();

                return View(playerVM);
            }
        }

        //
        // GET: /Player/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            Player player = playerdao.GetById(id);
            playerdao.Delete(player);
            return RedirectToAction("Team", "Player", new { id = player.Team.Id });
        }

        //
        // POST: /Player/Delete/5
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
