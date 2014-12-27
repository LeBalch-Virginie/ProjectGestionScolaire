using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GestionScolaire.Areas.GestionDesClasses.Models;
using GestionScolaire.Areas.Administration.Models;

namespace GestionScolaire.Areas.Eval.Models
{
    public class EvaluationModels
    {
        [Display(Name = "Id de l'evaluation")]
        public Guid id { get; set; }

        [Display(Name = "Id de la classe")]
        public Guid classroomId { get; set; }

        [Display(Name = "Id du user associée")]
        public Guid userId { get; set; }

        [Display(Name = "Id de la periode")]
        public Guid periodId { get; set; }

        [Display(Name = "date")]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        [Display(Name = "points totaux")]
        public int totalPoint { get; set; }

        

        public List<ClasseModels> classes { get; set; }

        public List<PeriodeModels> periodes { get; set; }

        public List<UserModels> users { get; set; }
    }
}