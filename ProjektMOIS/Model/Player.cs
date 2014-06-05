using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ProjektMOIS.Model
{
    public class Player : AbstractEntity
    {
        [Required(ErrorMessage="Jméno je povinné!")]
        public virtual String Name { get; set; }
        [Required(ErrorMessage = "Příjmení je povinné!")]
        public virtual String Surname { get; set; }
        [Required(ErrorMessage = "Post hráče je povinný!")]
        public virtual String Position { get; set; }
        [Required(ErrorMessage = "Datum narozenní je povinný!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:DD.MM.YYYY}")]
        public virtual DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Číslo dresu je povinné!")]
        [Range(1, 99, ErrorMessage="Číslo dresu musí být 1 až 99!")]
        public virtual int Number { get; set; }
        [Required(ErrorMessage = "Zadejte rodnou zem!")]
        public virtual String Country { get; set; }
        [Required(ErrorMessage = "Jedná se o aktivního hráče?!")]
        public virtual Boolean Active { get; set; }
        public virtual Team Team { get; set; }
        public virtual byte[] Photo { get; set; }
        public virtual String CountryName
        {
            get
            {
                return new RegionInfo(Country).DisplayName;
            }
        }
    }
}