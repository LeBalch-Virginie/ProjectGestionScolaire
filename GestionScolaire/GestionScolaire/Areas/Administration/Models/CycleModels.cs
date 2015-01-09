using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionScolaire.Areas.Administration.Models
{
    public class CycleModels
    {
        [Display(Name = "Id du cycle")]
        public Guid id { get; set; }

        [Display(Name = "Titre du cycle")]
        [StringLength(50)]
        [Required]
        public String title { get; set; }

        [Display(Name = "Liste des niveaux")]
        public List<NiveauModels> niveaux { get; set; }
    }


}