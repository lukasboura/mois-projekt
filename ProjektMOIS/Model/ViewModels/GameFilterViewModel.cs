using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektMOIS.Model
{
    public class GameFilterViewModel
    {
        public long Team { get; set; }
        public long Season { get; set; }
        public long? Competition { get; set; } 
    }
}