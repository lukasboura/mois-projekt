using ProjektMOIS.DAO;
using ProjektMOIS.Model.Others;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektMOIS.Model
{
    public class MyListItems : IListItems
    {
        private ITeamDAO tymdao = new TeamDAO();
        private IPlayerDAO playerdao = new PlayerDAO();
        private ISeasonDAO seasondao = new SeasonDAO();
        private ICompetitionDAO competitiondao = new CompetitionDAO();

        public IEnumerable<SelectListItem> Teams()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            IList<Team> tymy = tymdao.GetAll();

            foreach (Team t in tymy)
            {
                items.Add(new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Name
                });
            };

            items.Add(new SelectListItem
            {
                Value = "0",
                Text = "Bývalý hráč"
            });

            return items;
        }
        public IEnumerable<SelectListItem> TeamsOnly()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            IList<Team> tymy = tymdao.GetAll();

            foreach (Team t in tymy)
            {
                items.Add(new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Name
                });
            };

            return items;
        }

        public IEnumerable<SelectListItem> Players()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            IList<Player> players = playerdao.GetAll();

            foreach (Player p in players)
            {
                items.Add(new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name + " " + p.Surname
                });
            };

            return items;
        }

        public IEnumerable<SelectListItem> Positions()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem
            {
                Text = "Brankář",
                Value = "Brankář"
            });
            items.Add(new SelectListItem
            {
                Text = "Obránce",
                Value = "Obránce"
            });
            items.Add(new SelectListItem
            {
                Text = "Záložník",
                Value = "Záložník"
            });
            items.Add(new SelectListItem
            {
                Text = "Útočník",
                Value = "Útočník"
            });

            return items;
        }

        public IEnumerable<SelectListItem> Places()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem
            {
                Text = "Doma",
                Value = "Doma"
            });
            items.Add(new SelectListItem
            {
                Text = "Venku",
                Value = "Venku"
            });

            return items;
        }

        public IEnumerable<SelectListItem> Countries()
        {
            IEnumerable<SelectListItem> items = GetCountries()
                .Select(c => new SelectListItem
                {
                    Value = c.ID.ToString().ToLower(),
                    Text = c.Name
                });

            return items;
        }

        public IEnumerable<SelectListItem> UnsetPeriods(IList<GameStats> stats)
        {
            IList<SelectListItem> items = new List<SelectListItem>();

            string[] array = new string[4] { "1. Poločas", "2. Poločas", "Prodloužení", "Penalty" };
            List<string> periods = new List<string>(array);
            
            foreach (GameStats gs in stats)
            {
                periods.Remove(gs.Period);
                periods.Remove(gs.Period.ToLower());
            }
            foreach (String p in periods)
            {
                items.Add(new SelectListItem
                {
                    Value = p,
                    Text = p
                });
            };

            return items;
        }

        public IEnumerable<SelectListItem> UnsetPlayers(IList<PlayerStats> stats)
        {
            IList<SelectListItem> items = new List<SelectListItem>();

            IList<Player> players = playerdao.GetByActive(true);
            foreach (PlayerStats ps in stats)
            {
                players = players.Where(p => p.Id != ps.Player.Id).ToList();
            }

            foreach (Player p in players)
            {
                items.Add(new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name + " " + p.Surname
                });
            };

            return items;
        }

        public IEnumerable<Country> GetCountries()
        {
            return CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                 .Select(x => new Country
                 {
                     ID = new RegionInfo(x.LCID).Name,
                     Name = new RegionInfo(x.LCID).DisplayName
                 })
                                 .GroupBy(c => c.ID)
                                 .Select(c => c.First())
                                 .OrderBy(x => x.Name);
        }

        public IEnumerable<SelectListItem> Seasons()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            IList<Season> seasons = seasondao.GetAll();

            foreach (Season s in seasons)
            {
                items.Add(new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Value
                });
            };

            return items;
        }

        public IEnumerable<SelectListItem> Competitions()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            IList<Competition> competitions = competitiondao.GetAll();


            items.Add(new SelectListItem
            {
                Value = "",
                Text = "Všechny soutěže",
                Selected = true
            });

            foreach (Competition c in competitions)
            {
                items.Add(new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });
            };

            return items;
        }

        public IEnumerable<SelectListItem> CompetitionsOfTeam(long id)
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            IList<Competition> competitions = competitiondao.GetByTeam(id);


            items.Add(new SelectListItem
            {
                Value = "",
                Text = "Vyberte soutěž",
                Selected = true
            });

            foreach (Competition c in competitions)
            {
                items.Add(new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });
            };

            return items;
        }

        public IEnumerable<SelectListItem> CompetitionsOfPlayer(long id)
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            IList<Competition> competitions = competitiondao.GetByPlayer(id);


            items.Add(new SelectListItem
            {
                Value = "",
                Text = "Všechny soutěže",
                Selected = true
            });

            foreach (Competition c in competitions)
            {
                items.Add(new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });
            };

            return items;
        }

        public IEnumerable<SelectListItem> CompetitionsOnly()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            IList<Competition> competitions = competitiondao.GetAll();

            foreach (Competition c in competitions)
            {
                items.Add(new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });
            };

            return items;
        }


        public IEnumerable<SelectListItem> Roles()
        {
            IList<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem
            {
                Text = "Trenér",
                Value = "Trenér"
            });
            items.Add(new SelectListItem
            {
                Text = "Hráč",
                Value = "Hráč"
            });
            items.Add(new SelectListItem
            {
                Text = "Admin",
                Value = "Admin"
            });
            items.Add(new SelectListItem
            {
                Text = "Lékař",
                Value = "Lékař"
            });
            items.Add(new SelectListItem
            {
                Text = "Manažer",
                Value = "Manažer"
            });
            items.Add(new SelectListItem
            {
                Text = "Uživatel",
                Value = "Uživatel"
            });
            return items;
        }
    }
}