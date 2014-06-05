using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektMOIS.Model.Others
{
    public class PlayerStatsManager
    {
        private IList<PlayerStats> Stats;

        public PlayerStatsManager(IList<PlayerStats> Stats) 
        {
            this.Stats = Stats;
        }

        public IList<KeyValuePair<string, int>> OverAllStats()
        {
            IList<KeyValuePair<string, int>> results = new List<KeyValuePair<string, int>>();

            results.Add(new KeyValuePair<string, int>("Zápasy", Stats.Count));
            results.Add(new KeyValuePair<string, int>("Minuty", Stats.Sum(x => x.Minutes)));
            results.Add(new KeyValuePair<string, int>("Vstřelené góly", Stats.Sum(x => x.Goals)));
            results.Add(new KeyValuePair<string, int>("Asistence", Stats.Sum(x => x.Assists)));
            results.Add(new KeyValuePair<string, int>("Střely celkem", Stats.Sum(x => x.Shots)));
            results.Add(new KeyValuePair<string, int>("Střely mimo", Stats.Sum(x => x.ShotsWide)));
            results.Add(new KeyValuePair<string, int>("Ofsajdy", Stats.Sum(x => x.Offsides)));
            results.Add(new KeyValuePair<string, int>("Rohové kopy", Stats.Sum(x => x.Corners)));
            results.Add(new KeyValuePair<string, int>("Žluté karty", Stats.Sum(x => x.Yellow)));
            results.Add(new KeyValuePair<string, int>("Červené karty", Stats.Sum(x => x.Red)));

            return results;
        }

        public IList<KeyValuePair<string, int>> StatsForRadarChart()
        {
            IList<KeyValuePair<string, int>> results = new List<KeyValuePair<string, int>>();

            var games = Stats.Count;

            results.Add(new KeyValuePair<string, int>("Vstřelené góly", games != 0 ? Stats.Sum(x => x.Goals) / games : 0));
            results.Add(new KeyValuePair<string, int>("Asistence", games != 0 ? Stats.Sum(x => x.Assists) / games : 0));
            results.Add(new KeyValuePair<string, int>("Střely celkem", games != 0 ? Stats.Sum(x => x.Shots) / games : 0));
            results.Add(new KeyValuePair<string, int>("Střely mimo", games != 0 ? Stats.Sum(x => x.ShotsWide) / games : 0));
            results.Add(new KeyValuePair<string, int>("Ofsajdy", games != 0 ? Stats.Sum(x => x.Offsides) / games : 0));
            results.Add(new KeyValuePair<string, int>("Rohové kopy", games != 0 ? Stats.Sum(x => x.Corners) / games : 0));
            results.Add(new KeyValuePair<string, int>("Žluté karty", games != 0 ? Stats.Sum(x => x.Yellow) / games : 0));
            results.Add(new KeyValuePair<string, int>("Červené karty", games != 0 ? Stats.Sum(x => x.Red) / games : 0));

            return results;
        }
    }
}