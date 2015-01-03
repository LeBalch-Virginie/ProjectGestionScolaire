﻿using System;
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
        [Required]
        public String userName { get; set; }

        [Display(Name = "mot de passe")]
        [Required]
        public String password { get; set; }

        [Display(Name = "prénom")]
        [Required]
        public String firstName { get; set; }

        [Display(Name = "nom")]
        [Required]
        public String lastName { get; set; }

        [Display(Name = "mail")]
        [Required]
        public String mail { get; set; }

        public int mode { get; set; }

        public List<EtablissementModels> etablissements { get; set; }

        public List<ClasseModels> classes { get; set; }

    }
}