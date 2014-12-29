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
        public String name { get; set; }

        [Display(Name = "Adresse")]
        public String address { get; set; }

        [Display(Name = "Code postal")]
        public String postCode { get; set; }

        [Display(Name = "Ville")]
        public String town { get; set; }

        [Display(Name = "Directeur")]
        public Guid userId { get; set; }

        [Display(Name = "Académie")]
        public Guid academieId { get; set; }


        [Display(Name = "Directeur")]
        public String userName { get; set; }

        [Display(Name = "Académie")]
        public String academieName { get; set; }


        public List<AcademieModels> academies { get; set; }

        public List<UserModels> users { get; set; }

        public int mode { get; set; }
    }
}