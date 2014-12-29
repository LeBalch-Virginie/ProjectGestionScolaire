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
        public String lastName { get; set; }

        [Display(Name = "Prénom")]
        public String firstName { get; set; }

        [Display(Name = "Adresse")]
        public String address { get; set; }

        [Display(Name = "Code postal")]
        public String postCode { get; set; }

        [Display(Name = "Ville")]
        public String town { get; set; }

        [Display(Name = "Téléphone")]
        public String tel { get; set; }

        [Display(Name = "Mail")]
        public String mail { get; set; }

        [Display(Name = "Commentaire")]
        public String comment { get; set; }

        [Display(Name = "Liste des élèves")]
        public String eleves { get; set; }

        public int mode { get; set; }
    }
}