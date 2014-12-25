using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GestionScolaire.Areas.Administration.Models;

namespace GestionScolaire.Areas.Administration.Models
{
    public class AnneeModels
    {
        [Display(Name = "Id de l'année")]
        public Guid id { get; set; }

        [Display(Name = "Année")]
        public int year { get; set; }

        [Display(Name = "Liste des périodes")]
        public List<PeriodeModels> periods { get; set; }
    }
}