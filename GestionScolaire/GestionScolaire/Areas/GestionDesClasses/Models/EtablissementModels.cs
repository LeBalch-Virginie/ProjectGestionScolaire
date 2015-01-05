using GestionScolaire.Areas.GestionDesClasses.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionScolaire.Areas.GestionDesClasses.Models
{
    public class EtablissementModels
    {
        [Display(Name = "Id de l'etablissement")]
        public Guid id { get; set; }

        [Display(Name = "Nom de l'établissement")]
        [Required]
        public String name { get; set; }

        [Display(Name = "Adresse")]
        [Required]
        public String address { get; set; }

        [Display(Name = "Code postal")]
        [StringLength(5)]
        [Required]
        public String postCode { get; set; }

        [Display(Name = "Ville")]
        [Required]
        public String town { get; set; }

        [Display(Name = "Directeur")]
        [Required]
        public Guid userId { get; set; }

        [Display(Name = "Académie")]
        [Required]
        public Guid academieId { get; set; }

        [Display(Name = "Directeur")]
        [Required]
        public String userName { get; set; }

        [Display(Name = "Académie")]
        [Required]
        public String academieName { get; set; }


        public List<AcademieModels> academies { get; set; }

        public List<UserModels> users { get; set; }

        public List<ClasseModels> classrooms { get; set; }

        public int mode { get; set; }
    }
}