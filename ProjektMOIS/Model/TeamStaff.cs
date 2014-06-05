using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektMOIS.Model
{
    public class TeamStaff : AbstractEntity
    {
        [Required(ErrorMessage="Zadejte tým!")]
        public virtual Team Team { get; set; }
        public virtual Staff Staff { get; set; }
        [Required(ErrorMessage = "Zadejte roli ve vybraném týmu!")]
        public virtual String Role { get; set; }
    }
}