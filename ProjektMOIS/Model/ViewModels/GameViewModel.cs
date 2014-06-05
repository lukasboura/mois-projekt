using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektMOIS.Model
{
    public class GameViewModel
    {
        public Game Game { get; set; }
        public IList<GameStats> Stats { get; set; }
        public IList<PlayerStats> PlayerStats { get; set; }
    }
}