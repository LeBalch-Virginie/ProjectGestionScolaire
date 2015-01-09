using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace GestionScolaire.Areas.GestionDesClasses.Models
{
    public class AcademieModels
    {
        [Display(Name = "Id de l'académie")]
        
        public Guid id { get; set; }

        [Display(Name = "Nom de l'académie")]
        [Required]
        public String name { get; set; }

        [Display(Name = "Etablissements")]
        [Required]
        public List<EtablissementModels> etablissements { get; set; }

        public int mode { get; set; }
    }
}