using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektMOIS.Model
{
    public class GameStats : AbstractEntity
    {
        public virtual Game Game { get; set; }
        public virtual String Period { get; set; }
        public virtual int GoalsHome { get; set; }
        public virtual int GoalsAway { get; set; }
        public virtual int PossessionHome { get; set; }
        public virtual int PossessionAway { get; set; }
        public virtual int RedHome { get; set; }
        public virtual int RedAway { get; set; }
        public virtual int YellowHome { get; set; }
        public virtual int YellowAway { get; set; }
        public virtual int CornersHome { get; set; }
        public virtual int CornersAway { get; set; }
        public virtual int ShotsHome { get; set; }
        public virtual int ShotsAway { get; set; }
        public virtual int ShotsWideHome { get; set; }
        public virtual int ShotsWideAway { get; set; }
        public virtual int OffsidesHome { get; set; }
        public virtual int OffsidesAway { get; set; }
    }
}