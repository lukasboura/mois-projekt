using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektMOIS.Model
{
    public class Game : AbstractEntity
    {
        [Required(ErrorMessage = "Datum a čas jsou povinné.")]
        public virtual DateTime Date { get; set; }
        public virtual String Place { get; set; }
        public virtual String Report { get; set; }
        public virtual String ReportMarkdown { get; set; }
        [Required(ErrorMessage = "Jméno soupeře je povinné.")]
        public virtual String Opponent { get; set; }
        public virtual Team Team { get; set; }
        public virtual Season Season { get; set; }
        public virtual Competition Competition { get; set; }
        public virtual Iesi.Collections.Generic.ISet<GameStats> Stats { get; set; }
        public virtual Iesi.Collections.Generic.ISet<PlayerStats> PlayerStats { get; set; }

        public virtual String Title()
        {
            return Place == "Doma" ? Team.Name + " - " + Opponent : Opponent + " - " + Team.Name;
        }

        public virtual String Result()
        {
            String result = GoalsHome() + " : " + GoalsAway();
            if (Stats.Count == 2)
                return result;
            else if (Stats.Count == 3)
                return result + " pr.";
            else
                return result + " pen.";
        }

        public virtual int GoalsHome()
        {
            var shootout = ShootoutGoals("Home");
            return Stats.Where(x => x.Period != "Penalty").Sum(x => x.GoalsHome) + shootout;
        }

        public virtual int GoalsAway()
        {
            var shootout = ShootoutGoals("Away");
            return Stats.Where(x => x.Period != "Penalty").Sum(x => x.GoalsAway) + shootout;
        }

        public virtual int PossessionHome()
        {
            int divider = Stats.Count > 2 ? 3 : 2;
            return Stats.Where(x => x.Period != "Penalty").Sum(x => x.PossessionHome) / divider;
        }

        public virtual int PossessionAway()
        {
            int divider = Stats.Count > 2 ? 3 : 2;
            return Stats.Where(x => x.Period != "Penalty").Sum(x => x.PossessionAway) / divider;
        }

        public virtual int RedHome()
        {
            return Stats.Where(x => x.Period != "Penalty").Sum(x => x.RedHome);
        }

        public virtual int RedAway()
        {
            return Stats.Where(x => x.Period != "Penalty").Sum(x => x.RedAway);
        }
        public virtual int YellowHome()
        {
            return Stats.Where(x => x.Period != "Penalty").Sum(x => x.YellowHome);
        }
        public virtual int YellowAway()
        {
            return Stats.Where(x => x.Period != "Penalty").Sum(x => x.YellowAway);
        }
        public virtual int CornersHome()
        {
            return Stats.Where(x => x.Period != "Penalty").Sum(x => x.CornersHome);
        }
        public virtual int CornersAway()
        {
            return Stats.Where(x => x.Period != "Penalty").Sum(x => x.CornersAway);
        }
        public virtual int ShotsHome()
        {
            return Stats.Where(x => x.Period != "Penalty").Sum(x => x.ShotsHome);
        }
        public virtual int ShotsAway()
        {
            return Stats.Where(x => x.Period != "Penalty").Sum(x => x.ShotsAway);
        }
        public virtual int ShotsWideHome()
        {
            return Stats.Where(x => x.Period != "Penalty").Sum(x => x.ShotsWideHome);
        }
        public virtual int ShotsWideAway()
        {
            return Stats.Where(x => x.Period != "Penalty").Sum(x => x.ShotsWideAway);
        }
        public virtual int OffsidesHome()
        {
            return Stats.Where(x => x.Period != "Penalty").Sum(x => x.OffsidesHome);
        }
        public virtual int OffsidesAway()
        {
            return Stats.Where(x => x.Period != "Penalty").Sum(x => x.OffsidesAway);
        }
        private int ShootoutGoals(String played)
        {
            var shootout = 0;
            if (Stats.Any(x => x.Period == "Penalty"))
            {
                var shootoutHome = Stats.Where(x => x.Period == "Penalty").Sum(x => x.GoalsHome);
                var shootoutAway = Stats.Where(x => x.Period == "Penalty").Sum(x => x.GoalsAway);
                if (played == "Home")
                {
                    shootout = shootoutHome > shootoutAway ? 1 : 0;
                }
                else 
                {
                    shootout = shootoutHome < shootoutAway ? 1 : 0;
                }
            }
            return shootout;
        }
    }
}