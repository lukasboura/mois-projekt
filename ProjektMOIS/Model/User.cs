using ProjektMOIS.DAO;
using ProjektMOIS.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ProjektMOIS.Model
{
    public class User : AbstractEntity
    {
        [Required(ErrorMessage = "Zadejte jméno!")]
        public virtual String Name { get; set; }
        [Required(ErrorMessage = "Zadejte příjmení!")]
        public virtual String Surname { get; set; }
        [Required(ErrorMessage = "Zadejte email!")]
        public virtual String Email { get; set; }
        [Required(ErrorMessage = "Zadejte heslo!")]
        public virtual String Password { get; set; }
        [Required(ErrorMessage = "Vyberte roly!")]
        public virtual String Role { get; set; }
    }
}