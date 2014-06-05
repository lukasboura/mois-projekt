using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektMOIS.Model.ViewModels
{
    public class StaffRoleViewModel
    {
        [Required(ErrorMessage="Vyberte tým!")]
        public long Team { get; set; }
        public long Staff { get; set; }
        [Required(ErrorMessage = "Zadejte roli v týmu!")]
        public String Role { get; set; } 
    }
}