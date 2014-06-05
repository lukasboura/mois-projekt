using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektMOIS.Model.ViewModels
{
    public class PlayerViewModel
    {
        public virtual long Id { get; set; }
        [Required(ErrorMessage = "Jméno je povinné!")]
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
        [Range(1, 99, ErrorMessage = "Číslo dresu musí být 1 až 99!")]
        public virtual int Number { get; set; }
        [Required(ErrorMessage = "Zadejte rodnou zem!")]
        public virtual String Country { get; set; }
        [Required(ErrorMessage = "Jedná se o aktivního hráče?!")]
        public virtual Boolean Active { get; set; }
        [Required(ErrorMessage = "Vyberte tým!")]
        public virtual long Team { get; set; }
        public virtual byte[] Photo { get; set; }

        public PlayerViewModel() { }

        public PlayerViewModel(Player player)
        {
            this.Id = player.Id;
            this.Name = player.Name;
            this.Surname = player.Surname;
            this.Position = player.Position;
            this.BirthDate = player.BirthDate;
            this.Number = player.Number;
            this.Country = player.Country;
            this.Active = player.Active;
            this.Team = player.Team.Id;
            this.Photo = player.Photo;

        }

        public Player ToPlayer()
        {
            Player player = new Player
            {
                Id = this.Id,
                Name = this.Name,
                Surname = this.Surname,
                Position = this.Position,
                BirthDate = this.BirthDate,
                Number = this.Number,
                Country = this.Country,
                Active = this.Active,
                Team = new Team{
                    Id= this.Team
                },
                Photo = this.Photo
            };

            return player;
        }
    }
}