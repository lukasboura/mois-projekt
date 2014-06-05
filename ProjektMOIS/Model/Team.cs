using Iesi.Collections.Generic;
using ProjektMOIS.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektMOIS.Model
{
    public class Team : AbstractEntity
    {
        [Required(ErrorMessage="Zadejte název týmu!")]
        public virtual String Name { get; set; }
        public virtual Iesi.Collections.Generic.ISet<Player> Players { get; set; }
        public virtual Iesi.Collections.Generic.ISet<Competition> Competitions { get; set; }
        public virtual Iesi.Collections.Generic.ISet<TeamStaff> Staffs { get; set; }

    }
}