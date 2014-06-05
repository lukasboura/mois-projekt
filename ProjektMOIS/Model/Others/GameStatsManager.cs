using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace ProjektMOIS.Model.Others
{
    public class Data
    {
        public int Value { get; set; }
        public String Color { get; set; }
    };

    public class GameStatsManager
    {
        private IList<Game> Games { get; set; }

        private String Home = "Doma";
        private String Away = "Venku";

        private static String Red = "#d11141";
        private static String Green = "#00b159";
        private static String Blue = "#00aedb";
        private static String Orange = "#f37735";
        private static String Yellow = "#ffc425";
        private static String[] Colors = new String[] { Red, Green, Blue, Orange, Yellow };

        public GameStatsManager(IList<Game> games)
        {
            this.Games = games;
        }

        public IList<KeyValuePair<string, int>> OverAllStats() 
        {
            IList<KeyValuePair<string, int>> results = new List<KeyValuePair<string, int>>();

            results.Add(new KeyValuePair<string, int>("Zápasy", Games.Where(x => x.Stats.Count >= 2 && x.Date < DateTime.Now).Count()));
            results.Add(new KeyValuePair<string, int>("Vstřelené", Games.Where(x => x.Place == Home).Sum(x => x.GoalsHome()) + Games.Where(x => x.Place == Away).Sum(x => x.GoalsAway())));
            results.Add(new KeyValuePair<string, int>("Obdržené", Games.Where(x => x.Place == Home).Sum(x => x.GoalsAway()) + Games.Where(x => x.Place == Away).Sum(x => x.GoalsHome())));
            results.Add(new KeyValuePair<string, int>("Držení míže", Games.Where(x => x.Place == Home).Sum(x => x.PossessionHome()) + Games.Where(x => x.Place == Away).Sum(x => x.PossessionAway())));
            results.Add(new KeyValuePair<string, int>("Střely celkem", Games.Where(x => x.Place == Home).Sum(x => x.ShotsHome()) + Games.Where(x => x.Place == Away).Sum(x => x.ShotsAway())));
            results.Add(new KeyValuePair<string, int>("Střely mimo", Games.Where(x => x.Place == Home).Sum(x => x.ShotsWideHome()) + Games.Where(x => x.Place == Away).Sum(x => x.ShotsWideAway())));
            results.Add(new KeyValuePair<string, int>("Ofsajdy", Games.Where(x => x.Place == Home).Sum(x => x.OffsidesHome()) + Games.Where(x => x.Place == Away).Sum(x => x.OffsidesAway())));
            results.Add(new KeyValuePair<string, int>("Rohové kopy", Games.Where(x => x.Place == Home).Sum(x => x.CornersHome()) + Games.Where(x => x.Place == Away).Sum(x => x.CornersAway())));
            results.Add(new KeyValuePair<string, int>("Žluté karty", Games.Where(x => x.Place == Home).Sum(x => x.YellowHome()) + Games.Where(x => x.Place == Away).Sum(x => x.YellowAway())));
            results.Add(new KeyValuePair<string, int>("Červené karty", Games.Where(x => x.Place == Home).Sum(x => x.RedHome()) + Games.Where(x => x.Place == Away).Sum(x => x.RedAway())));
            
            return results;
        }

        public OrderedDictionary Results()
        {
            OrderedDictionary results = new OrderedDictionary();
            results.Add("Prohry", new Data
            {
                Value = Games.Where(x => (x.Date < DateTime.Now && x.Stats.Count >= 2) && (x.Place == Home && x.GoalsHome() > x.GoalsAway()) || (x.Place == Away && x.GoalsHome() < x.GoalsAway())).Count(),
                Color = Red
            });
            results.Add("Výhry", new Data
            {
                Value = Games.Where(x => (x.Date < DateTime.Now && x.Stats.Count >= 2) && (x.Place == Home && x.GoalsHome() < x.GoalsAway()) || (x.Place == Away && x.GoalsHome() > x.GoalsAway())).Count(),
                Color = Green
            });
            results.Add("Remízy", new Data
            {
                Value = Games.Where(x => (x.Date < DateTime.Now && x.Stats.Count >= 2) && (x.GoalsHome() == x.GoalsAway())).Count(),
                Color = Blue
            });
            return results;
        }

        public OrderedDictionary Goals()
        {
            OrderedDictionary results = new OrderedDictionary();
            results.Add("0", new Data
            {
                Value = Games.Where(x => (x.Date < DateTime.Now && x.Stats.Count >= 2) && (x.Place == Home && x.GoalsHome() == 0) || (x.Place == Away && x.GoalsAway() == 0)).Count(),
                Color = Red
            });
            results.Add("1 až 2", new Data
            {
                Value = Games.Where(x => (x.Date < DateTime.Now && x.Stats.Count >= 2) && (x.Place == Home && 1 <= x.GoalsHome() && x.GoalsHome() <= 2) || (x.Place == Away && 1 <= x.GoalsAway() && x.GoalsAway() <= 2)).Count(),
                Color = Green
            });
            results.Add("3 až 4", new Data
            {
                Value = Games.Where(x => (x.Date < DateTime.Now && x.Stats.Count >= 2) && (x.Place == Home && 3 <= x.GoalsHome() && x.GoalsHome() <= 4) || (x.Place == Away && 3 <= x.GoalsAway() && x.GoalsAway() <= 4)).Count(),
                Color = Blue
            });
            results.Add("5 a více", new Data
            {
                Value = Games.Where(x => (x.Date < DateTime.Now && x.Stats.Count >= 2) && (x.Place == Home && x.GoalsHome() >= 5) || (x.Place == Away && x.GoalsAway() >= 5)).Count(),
                Color = Orange
            });
            return results;
        }

        public OrderedDictionary Shooters()
        {
            OrderedDictionary results = new OrderedDictionary();
            Dictionary<string, int> goals = new Dictionary<string, int>();

            foreach (Game g in Games)
            {
                foreach (PlayerStats ps in g.PlayerStats)
                {
                    int pGoals = 0;
                    goals.TryGetValue(ps.Player.Name + " " + ps.Player.Surname, out pGoals);
                    //int pGoals = goals[ps.Player.Name + " " + ps.Player.Surname];
                    goals.Add(ps.Player.Name + " " + ps.Player.Surname, pGoals + ps.Goals);
                }
            }

            List<KeyValuePair<string, int>> myList = goals.ToList();

            myList.Sort((firstPair, nextPair) =>
            {
                return nextPair.Value.CompareTo(firstPair.Value);
            }
            );

            int count = myList.Count <= 5 ? myList.Count : 5;

            for (int i = 0; i < count; i++)
            {
                results.Add(myList.ElementAt(i).Key, new Data
                {
                    Value = myList.ElementAt(i).Value,
                    Color = Colors[i]
                });
            }

            if (myList.Count > 5)
            {
                int goalsOthers = 0;
                foreach (var item in myList) 
                {
                    goalsOthers += item.Value;
                }
                results.Add("Ostatní", new Data
                {
                    Value = goalsOthers,
                    Color = "#7109aa"
                });
            }


            return results;
        }
    }
}