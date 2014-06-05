using ProjektMOIS.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektMOIS.Model.ViewModels
{
    public class EditUserViewModel
    {
        public virtual long Id { get; set; }
        [Required(ErrorMessage = "Zadejte jméno!")]
        public virtual String Name { get; set; }
        [Required(ErrorMessage = "Zadejte příjmení!")]
        public virtual String Surname { get; set; }
        [Required(ErrorMessage = "Zadejte email!")]
        public virtual String Email { get; set; }
        [Required(ErrorMessage = "Zadejte heslo!")]
        public virtual String Password { get; set; }
        public virtual String NewPassword { get; set; }
        [Required(ErrorMessage = "Vyberte roly!")]
        public virtual String Role { get; set; }

        public EditUserViewModel() { }

        public EditUserViewModel(User user)
        {
            this.Id = user.Id;
            this.Name = user.Name;
            this.Surname = user.Surname;
            this.Email = user.Email;
            this.Password = user.Password;
            this.NewPassword = "";
            this.Role = user.Role;

        }

        public User ToUser()
        {
            String pass = null;
            if (this.NewPassword != null)
            {
                pass = MD5.Encode(this.NewPassword);

            }
            else
            {
                pass = this.Password;

            }

            User user = new User
            {
                Id = this.Id,
                Name = this.Name,
                Surname = this.Surname,
                Email = this.Email,
                Password = pass,
                Role = this.Role
            };

            return user;
        }
    }
}