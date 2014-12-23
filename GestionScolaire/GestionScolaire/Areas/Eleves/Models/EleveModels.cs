using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GestionScolaire.Areas.GestionDesClasses.Models;
using GestionScolaire.Models;
using GestionScolaire.Areas.Administration.Models;

namespace GestionScolaire.Areas.Eleves.Models
{
    public class EleveModels
    {
        [Display(Name = "Id de l'eleve")]
        public Guid id { get; set; }

        [Display(Name = "Prénom")]
        public String firstName { get; set; }

        [Display(Name = "Nom")]
        public String lastName { get; set; }

        public short state { get; set; }

        [Display(Name = "sexe")]
        public short sexe { get; set; }


        [Display(Name = "date d'anniversaire")]
        public DateTime birthdayDate { get; set; }

        [Display(Name = "Id du tuteur")]
        public Guid tuteurId { get; set; }

        [Display(Name = "Id de la classe")]
        public Guid classroomId { get; set; }

        [Display(Name = "Id du niveau")]
        public Guid levelId { get; set; }

        public List<TuteurModels> tuteurs { get; set; }

        public List<ClasseModels> classes { get; set; }

        public List<NiveauModels> niveaux { get; set; }


    }
}
