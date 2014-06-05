using Iesi.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ProjektMOIS.Model
{
    public class Staff : AbstractEntity
    {
        [Required(ErrorMessage = "Jméno je povinné!")]
        public virtual String Name { get; set; }
        [Required(ErrorMessage = "Příjmení je povinné!")]
        public virtual String Surname { get; set; }
        [Required(ErrorMessage = "Datum narozenní je povinný!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:DD.MM.YYYY}")]
        public virtual DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Zadejte rodnou zem!")]
        public virtual String Country { get; set; }
        public virtual byte[] Photo { get; set; }
        public virtual String CountryName
        {
            get
            {
                return new RegionInfo(Country).DisplayName;
            }
        }
        public virtual Iesi.Collections.Generic.ISet<TeamStaff> Teams { get; set; }
    }
}