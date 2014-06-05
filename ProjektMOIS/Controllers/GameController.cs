using MarkdownDeep;
using ProjektMOIS.DAO;
using ProjektMOIS.Model;
using ProjektMOIS.Model.Others;
using ProjektMOIS.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektMOIS.Controllers
{
    public class GameController : Controller
    {
        private IGameDAO gamedao = new GameDAO();
        private ITeamDAO teamdao = new TeamDAO();
        private ISeasonDAO seasondao = new SeasonDAO();
        private ICompetitionDAO compdao = new CompetitionDAO();
        private IGameStatsDAO gsdao = new GameStatsDAO();
        private IPlayerStatsDAO psdao = new PlayerStatsDAO();
        private IListItems listItems = new MyListItems();
        //
        // GET: /Match/

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

            ViewBag.Games = games;

            return View();
        }

        //
        // GET: /Match/Details/5

        public ActionResult Details(int id)
        {
            ViewBag.Game = gamedao.GetById(id);
            return View();
        }

        //
        // GET: /Match/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.TeamItems = listItems.TeamsOnly();
            ViewBag.SeasonItems = listItems.Seasons();
            ViewBag.CompetitionItems = listItems.CompetitionsOnly();
            ViewBag.PlaceItems = listItems.Places();

            return View();
        }

        //
        // POST: /Match/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult CreateStats(int id, String period)
        {
            GameStats stats = new GameStats();
            stats.Period = period;
            stats.PossessionHome = 50;
            stats.PossessionAway = 50;
            stats.Period = period;
            stats.Game = new Game() { Id = id };
            gsdao.Create(stats);

            return RedirectToAction("Edit", "Game", new { id = id });
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult CreatePlayerStats(int id, int playerid)
        {
            PlayerStats stats = new PlayerStats();
            stats.Player = new Player() { Id = playerid };
            stats.Game = new Game() { Id = id };
            psdao.Create(stats);

            return RedirectToAction("Edit", "Game", new { id = id });
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult UpdateStats(int id, GameViewModel model)
        {
            if (ModelState.IsValidField("Stats"))
            {
                IList<GameStats> stats = model.Stats;

                foreach (GameStats gs in stats)
                {
                    gsdao.Update(gs);
                }

                return RedirectToAction("Edit", "Game", new { id = id });
            }


            return RedirectToAction("Edit", "Game", new { id = model.Game.Id });
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult UpdatePlayerStats(int id, GameViewModel model)
        {
            if (ModelState.IsValidField("PlayerStats"))
            {
                IList<PlayerStats> stats = model.PlayerStats;

                foreach (PlayerStats ps in stats)
                {
                    psdao.Update(ps);
                }

                return RedirectToAction("Edit", "Game", new { id = id });
            }


            return RedirectToAction("Edit", "Game", new { id = id });
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DeletePlayerStats(int id)
        {
            PlayerStats ps = psdao.GetById(id);
            psdao.Delete(ps);
            return RedirectToAction("Edit", "Game", new { id = ps.Game.Id });

        }

        public ActionResult DeleteGameStats(int id)
        {
            GameStats gs = gsdao.GetById(id);
            gsdao.Delete(gs);
            return RedirectToAction("Edit", "Game", new { id = gs.Game.Id });

        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(CreateGameViewModel cgvm)
        {
            Game game = new Game
            {
                Date = cgvm.Date,
                Place = cgvm.Place,
                Opponent = cgvm.Opponent
            };

            game.Team = new Team{Id = cgvm.Team};
            game.Season = new Season { Id = cgvm.Season };
            game.Competition = new Competition { Id = cgvm.Competition };

            if (ModelState.IsValid)
            {
                gamedao.Create(game);
                return RedirectToAction("Index", "Game");
            }
            ViewBag.TeamItems = listItems.TeamsOnly();
            ViewBag.SeasonItems = listItems.Seasons();
            ViewBag.CompetitionItems = listItems.CompetitionsOnly();
            ViewBag.PlaceItems = listItems.Places();
            return View(cgvm);

        }

        //
        // GET: /Match/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Game game = gamedao.GetById(id);
            GameViewModel model = new GameViewModel()
            {
                Game = game,
                Stats = game.Stats.ToList<GameStats>(),
                PlayerStats = game.PlayerStats.ToList<PlayerStats>()
            };

            ViewBag.PeriodsItems = listItems.UnsetPeriods(game.Stats.ToList<GameStats>());
            ViewBag.PlayersItems = listItems.UnsetPlayers(game.PlayerStats.ToList<PlayerStats>());
            ViewBag.PlaceItems = listItems.Places();

            return View(model);
        }

        //
        // POST: /Match/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(GameViewModel gamevm)
        {
            Game game = gamevm.Game;
            if (ModelState.IsValid)
            {
                Markdown md = new MarkdownDeep.Markdown();
                game.Report = md.Transform(game.ReportMarkdown);
                gamedao.Update(game);
                return RedirectToAction("Details", "Game", new { id = game.Id });
            }
            else
            {
                Game g = gamedao.GetById(game.Id);
                gamevm.Stats = g.Stats.ToList();
                gamevm.PlayerStats = g.PlayerStats.ToList();
                ViewBag.PeriodsItems = listItems.UnsetPeriods(g.Stats.ToList<GameStats>());
                ViewBag.PlayersItems = listItems.UnsetPlayers(g.PlayerStats.ToList<PlayerStats>());
                ViewBag.PlaceItems = listItems.Places();
                return View(gamevm);
            }
        }

        //
        // GET: /Match/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Match/Delete/5
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
