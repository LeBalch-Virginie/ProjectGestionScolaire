using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionScolaire.Models
{
    public class EtablissementModels
    {
        [Display(Name = "Id de l'etablissement")]
        public Guid id { get; set; }

        [Display(Name = "Nom de l'etablissement")]
        public String name { get; set; }

        [Display(Name = "Adresse")]
        public String address { get; set; }

        [Display(Name = "code postal")]
        public String postCode { get; set; }

        [Display(Name = "ville")]
        public String town { get; set; }

        [Display(Name = "Id l'utilisateur liée ")]
        public Guid userId { get; set; }

        [Display(Name = "Id de l'academie liée")]
        public Guid academieId { get; set; }


        [Display(Name = "nom de l'utilisateur liée ")]
        public String userName { get; set; }

        [Display(Name = "nom de l'academie liée ")]
        public String academieIdName { get; set; }


/// ////////////////////////////

        public System.Web.Mvc.SelectList AcademieIdNames;

        public AcademieModels academs { get; set; }
    }
}