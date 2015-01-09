using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GestionScolaire.Areas.GestionDesClasses.Models;
using GestionScolaire.Models;
using GestionScolaire.Areas.Administration.Models;
using GestionScolaire.Areas.Eval.Models;

namespace GestionScolaire.Areas.Eleves.Models
{
    public class EleveModels
    {
        [Display(Name = "Id de l'élève")]        
        public Guid id { get; set; }

        [Display(Name = "Prénom")]
        [StringLength(50)]
        [Required]
        public String firstName { get; set; }

        [Display(Name = "Nom")]
        [StringLength(50)]
        [Required]
        public String lastName { get; set; }

        public short state { get; set; }

        [Display(Name = "Sexe")]
        [Required]
        public short sexe { get; set; }

        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime birthdayDate { get; set; }

        [Display(Name = "Tuteur")]
        [Required]
        public Guid tuteurId { get; set; }

        [Display(Name = "Classe")]
        [Required]
        public Guid classroomId { get; set; }

        [Display(Name = "Niveau")]
        [Required]
        public Guid levelId { get; set; }

        public String tuteurName { get; set; }

        public String classTitle { get; set; }

        public String niveauName { get; set; }

        public List<TuteurModels> tuteurs { get; set; }

        public List<ClasseModels> classes { get; set; }

        public List<NiveauModels> niveaux { get; set; }

        public List<ResultatModels> resultats { get; set; }

        public int mode { get; set; }
    }
}
