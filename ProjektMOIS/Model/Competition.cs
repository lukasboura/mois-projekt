using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektMOIS.Model
{
    public class Competition : AbstractEntity
    {
        public virtual String Name { get; set; }
        public virtual Team Team { get; set; }
    }
}