using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionScolaire.Areas.Eleves.Models
{
    public class TuteurModels
    {
        [Display(Name = "Id du tuteur")]
        public Guid id { get; set; }

        [Display(Name = "Nom")]
        [Required]
        public String lastName { get; set; }

        [Display(Name = "Prénom")]
        [Required]
        public String firstName { get; set; }

        [Display(Name = "Adresse")]
        [Required]
        public String address { get; set; }

        [Display(Name = "Code postal")]
        [Required]
        public String postCode { get; set; }

        [Display(Name = "Ville")]
        [Required]
        public String town { get; set; }

        [Display(Name = "Téléphone")]
        [Required]
        public String tel { get; set; }

        [Display(Name = "Mail")]
        [EmailAddress]
        [Required]
        public String mail { get; set; }

        [Display(Name = "Commentaire")]
        [Required]
        public String comment { get; set; }

        [Display(Name = "Liste des élèves")]
        [Required]
        public String eleves { get; set; }

        public int mode { get; set; }
    }
}