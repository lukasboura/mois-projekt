using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektMOIS.Model
{
    public class PlayerStats : AbstractEntity
    {
        public virtual Player Player { get; set; }
        public virtual Game Game { get; set; }
        public virtual int Minutes { get; set; }
        public virtual int Goals { get; set; }
        public virtual int Assists { get; set; }
        public virtual int Red { get; set; }
        public virtual int Yellow { get; set; }
        public virtual int Corners { get; set; }
        public virtual int Shots { get; set; }
        public virtual int ShotsWide { get; set; }
        public virtual int Offsides { get; set; }
    }
}