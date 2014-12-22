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

        public String password { get; set; }

        public String firstName { get; set; }

        public String lastName { get; set; }

        public String mail { get; set; }
    }
}