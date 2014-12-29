using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionScolaire.Areas.GestionDesClasses.Models
{
    public class UserModels
    {
        [Display(Name = "Id de l'utilisateur")]
        public Guid id { get; set; }

        [Display(Name = "Nom de l'utilisateur")]
        public String userName { get; set; }

        [Display(Name = "mot de passe")]
        public String password { get; set; }

        [Display(Name = "prénom")]
        public String firstName { get; set; }

        [Display(Name = "nom")]
        public String lastName { get; set; }

        [Display(Name = "mail")]
        public String mail { get; set; }

        public int mode { get; set; }
    }
}