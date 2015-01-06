using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GestionScolaire.Areas.GestionDesClasses.Models;
using GestionScolaire.Areas.Administration.Models;
using GestionScolaire.Areas.Eleves.Models;
using GestionScolaire.Areas.Eval.Models;

namespace GestionScolaire.Areas.GestionDesClasses.Models
{
    public class ClasseModels
    {
        [Display(Name = "Id ")]
        public Guid id { get; set; }

        [Display(Name = "Nom de la classe")]
        [Required]
        public String title { get; set; }

        [Display(Name = "Professeur principal")]
        [Required]
        public Guid userId { get; set; }

        [Display(Name = "Année")]
        [Required]
        public Guid yearId { get; set; }

        [Display(Name = "Etablissement")]
        [Required]
        public Guid etablissementId { get; set; }

        [Display(Name = "utilisateur ")]
        [Required]
        public String userName { get; set; }

        [Display(Name = "année  ")]
        [Required]
        public int yearName { get; set; }

        [Display(Name = "nom'etablissement")]
        [Required]
        public String etablissementName { get; set; }


        public List<EtablissementModels> etablissements { get; set; }

        public List<UserModels> users { get; set; }

        public List<AnneeModels> years { get; set; }

        public List<EleveModels> pupils { get; set; }

        public List<EvaluationModels> evaluations { get; set; }

        public int mode { get; set; }

    }
}