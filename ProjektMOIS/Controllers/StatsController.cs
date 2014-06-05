using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProjektMOIS.DAO;
using ProjektMOIS.Model;
using ProjektMOIS.Model.Others;
using ProjektMOIS.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ProjektMOIS.Controllers
{
    public class StatsController : Controller
    {
        private IGameDAO gamedao = new GameDAO();
        private IPlayerStatsDAO psdao = new PlayerStatsDAO();
        private IListItems listItems = new MyListItems();
        //
        // GET: /Stats/

        public ActionResult Index(GameFilterViewModel model)
        {
            ViewBag.TeamItems = listItems.TeamsOnly();
            ViewBag.SeasonItems = listItems.Seasons();

            if (model.Team == 0 && model.Season == 0)
            {
                model.Season = Convert.ToInt64(ViewBag.SeasonItems[0].Value);
                model.Team = Convert.ToInt64(ViewBag.TeamItems[0].Value);
            }

            ViewBag.CompetitionItems = listItems.CompetitionsOfTeam(model.Team);

            IList<Game> games = gamedao.GetByFilter(model);

            GameStatsManager gsm = new GameStatsManager(games);

            ViewBag.Results = gsm.Results();
            ViewBag.Stats = gsm.OverAllStats();
            ViewBag.ResultsShooters = gsm.Shooters();
            ViewBag.ResultsGoals = gsm.Goals();
            return View();
        }

        public ActionResult Player(PlayerStatsFilterViewModel model)
        {
            ViewBag.PlayerItems = listItems.Players();
            ViewBag.SeasonItems = listItems.Seasons();

            if (model.Player == 0 && model.Season == 0)
            {
                model.Season = Convert.ToInt64(ViewBag.SeasonItems[0].Value);
                model.Player = Convert.ToInt64(ViewBag.PlayerItems[0].Value);
            }

            ViewBag.CompetitionItems = listItems.CompetitionsOfPlayer(model.Player);

            IList<PlayerStats> stats = psdao.GetByFilter(model);

            PlayerStatsManager gsm = new PlayerStatsManager(stats);

            ViewBag.Stats = gsm.OverAllStats();
            ViewBag.RadarStats = gsm.StatsForRadarChart();
            return View();
        }

    }
}
