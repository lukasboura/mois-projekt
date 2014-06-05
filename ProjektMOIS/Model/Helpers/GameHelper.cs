using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektMOIS.Model.Helpers
{
    public class GameHelper
    {
        public Game Game { get; set; }
        public GameHelper(Game game)
        {
            this.Game = game;
        }


        // virtual attributes not stored in database 
        public virtual String Title
        {
            get
            {
                if (Game.Place == "Doma")
                {
                    return Game.Team.Name + " - " + Game.Opponent;
                }
                else
                {
                    return Game.Opponent + " - " + Game.Team.Name;
                }
            }
        }
        public virtual String Result
        {
            get
            {
                int gh = 0;
                int ga = 0;
                foreach (GameStats gs in Game.Stats)
                {
                    if (gs.Period != "Penalty")
                    {
                        gh += gs.GoalsHome;
                        ga += gs.GoalsAway;
                    }
                }
                return gh + " : " + ga;
            }
        }

        // ---------------- Calculated Stats --------------
        public virtual int GoalsHome() { return Game.Stats.Where(x => x.Period != "Penalty").Sum(x => x.GoalsHome); }
        public virtual int GoalsAway() { return Game.Stats.Where(x => x.Period != "Penalty").Sum(x => x.GoalsHome); }
        public virtual int PossessionHome() { return Game.Stats.Where(x => x.Period != "Penalty").Sum(x => x.PossessionHome); ; }
        public virtual int PossessionAway() { return Game.Stats.Where(x => x.Period != "Penalty").Sum(x => x.PossessionAway); }
        public virtual int RedHome() { return Game.Stats.Where(x => x.Period != "Penalty").Sum(x => x.RedHome); }
        public virtual int RedAway() { return Game.Stats.Where(x => x.Period != "Penalty").Sum(x => x.RedAway); }
        public virtual int YellowHome() { return Game.Stats.Where(x => x.Period != "Penalty").Sum(x => x.YellowHome); }
        public virtual int YellowAway() { return Game.Stats.Where(x => x.Period != "Penalty").Sum(x => x.YellowAway); }
        public virtual int CornersHome() { return Game.Stats.Where(x => x.Period != "Penalty").Sum(x => x.CornersHome); }
        public virtual int CornersAway() { return Game.Stats.Where(x => x.Period != "Penalty").Sum(x => x.CornersAway); }
        public virtual int ShotsHome() { return Game.Stats.Where(x => x.Period != "Penalty").Sum(x => x.ShotsHome); }
        public virtual int ShotsAway() { return Game.Stats.Where(x => x.Period != "Penalty").Sum(x => x.ShotsAway); }
        public virtual int ShotsWideHome() { return Game.Stats.Where(x => x.Period != "Penalty").Sum(x => x.ShotsWideHome); }
        public virtual int ShotsWideAway() { return Game.Stats.Where(x => x.Period != "Penalty").Sum(x => x.ShotsWideAway); }
        public virtual int OffsidesHome() { return Game.Stats.Where(x => x.Period != "Penalty").Sum(x => x.OffsidesHome); }
        public virtual int OffsidesAway() { return Game.Stats.Where(x => x.Period != "Penalty").Sum(x => x.OffsidesAway); }
    }
}