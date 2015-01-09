using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GestionScolaire.Areas.Eval.Models;

namespace GestionScolaire.Areas.GestionDesClasses.Models
{
    public class UserModels
    {
        [Display(Name = "Id de l'utilisateur")]
        public Guid id { get; set; }

        [Display(Name = "Nom de l'utilisateur")]
        [StringLength(50)]
        [Required]
        public String userName { get; set; }

        [Display(Name = "mot de passe")]
        [StringLength(50)]
        [Required]
        [DataType(DataType.Password)]
        public String password { get; set; }

        [Display(Name = "prénom")]
        [StringLength(50)]
        [Required]
        public String firstName { get; set; }

        [Display(Name = "nom")]
        [StringLength(50)]
        [Required]
        public String lastName { get; set; }

        [Display(Name = "mail")]
        [StringLength(50)]
        [Required]
        [EmailAddress]
        public String mail { get; set; }

        public int mode { get; set; }

        public List<EtablissementModels> etablissements { get; set; }

        public List<ClasseModels> classes { get; set; }

        public List<EvaluationModels> evaluations { get; set; }

    }
}