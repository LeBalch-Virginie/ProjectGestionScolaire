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
        [StringLength(50)]
        [Required]
        public String lastName { get; set; }

        [Display(Name = "Prénom")]
        [StringLength(50)]
        [Required]
        public String firstName { get; set; }

        [Display(Name = "Adresse")]
        [StringLength(50)]
        [Required]
        public String address { get; set; }

        [Display(Name = "Code postal")]
        [Required]
        [StringLength(50)]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "Le code postal doit être un nombre.")]
        public String postCode { get; set; }

        [Display(Name = "Ville")]
        [StringLength(50)]
        [Required]
        public String town { get; set; }

        [Display(Name = "Téléphone")]
        [Required]
        [StringLength(50)]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "Le numéro de téléphone doit être un nombre.")]

        public String tel { get; set; }

        [Display(Name = "Mail")]
        [EmailAddress]
        [StringLength(50)]
        [Required]
        public String mail { get; set; }

        [Display(Name = "Commentaire")]
        [StringLength(100)]
        [Required]
        public String comment { get; set; }

        [Display(Name = "Liste des élèves")]
        public List<EleveModels> pupils { get; set; }

        public int mode { get; set; }
    }
}