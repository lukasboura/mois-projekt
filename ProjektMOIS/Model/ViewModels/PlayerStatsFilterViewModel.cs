using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektMOIS.Model.ViewModels
{
    public class PlayerStatsFilterViewModel
    {
        public long Player { get; set; }
        public long Season { get; set; }
        public long? Competition { get; set; } 
    }
}