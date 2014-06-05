using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektMOIS.Model.ViewModels
{
    public class CreateGameViewModel
    {
        [Required(ErrorMessage = "Datum a čas jsou povinné.")]
        public virtual DateTime Date { get; set; }
        public virtual String Place { get; set; }
        public virtual String Report { get; set; }
        public virtual String ReportMarkdown { get; set; }
        [Required(ErrorMessage = "Jméno soupeře je povinné.")]
        public virtual String Opponent { get; set; }
        public virtual long Team { get; set; }
        public virtual long Season { get; set; }
        public virtual long Competition { get; set; }
    }
}