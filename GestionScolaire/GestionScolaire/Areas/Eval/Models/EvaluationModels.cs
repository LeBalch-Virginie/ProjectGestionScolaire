using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GestionScolaire.Areas.GestionDesClasses.Models;
using GestionScolaire.Areas.Administration.Models;
using GestionScolaire.Areas.Eleves.Models;

namespace GestionScolaire.Areas.Eval.Models
{
    public class EvaluationModels
    {
        [Display(Name = "Id de l'évaluation")]
        public Guid id { get; set; }

        [Display(Name = "Classe")]
        [Required]
        public Guid classroomId { get; set; }

        [Display(Name = "Professeur")]
        [Required]
        public Guid userId { get; set; }

        [Display(Name = "Période")]
        [Required]
        public Guid periodId { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime date { get; set; }

        [Display(Name = "Points totaux")]
        [Required]
        [Range(1, 10000)]
        public int totalPoint { get; set; }

        [Display(Name = "Classe")]

        public String classroomName { get; set; }

        [Display(Name = "Professeur")]

        public String userName { get; set; }

        [Display(Name = "Période")]

        public DateTime periodName { get; set; }

        public List<ClasseModels> classes { get; set; }

        public List<PeriodeModels> periodes { get; set; }

        public List<UserModels> users { get; set; }

        public List<ResultatModels> resultats { get; set; }

        public List<EleveModels> eleves { get; set; }

        public int mode { get; set; }
    }
}