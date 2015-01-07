using GestionScolaire.Areas.Eval.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionScolaire.Areas.Administration.Models
{
    public class PeriodeModels
    {
        [Display(Name = "Id de la période")]
        public Guid id { get; set; }

        [Display(Name = "Début de la période")]
        public DateTime begin { get; set; }

        [Display(Name = "Fin de la période")]
        public DateTime end { get; set; }

        [Display(Name = "L'année à laquelle elle appartient")]
        public Guid yearId { get; set; }

        public int year { get; set; }

        public List<EvaluationModels> evaluations { get; set; }
    }
}