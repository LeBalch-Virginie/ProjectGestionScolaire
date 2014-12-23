using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GestionScolaire.Areas.GestionDesClasses.Models;
using GestionScolaire.Areas.Administration.Models;

namespace GestionScolaire.Areas.GestionDesClasses.Models
{
    public class ClasseModels
    {
        [Display(Name = "Id ")]
        public Guid id { get; set; }

        [Display(Name = "titre")]
        public String title { get; set; }

        [Display(Name = "Id l'utilisateur liée ")]
        public Guid userId { get; set; }

        [Display(Name = "Id de l'année liée ")]
        public Guid yearId { get; set; }

        [Display(Name = "Id de l'etablissement liée")]
        public Guid etablissementId { get; set; }


        public List<EtablissementModels> etablissements { get; set; }

        public List<UserModels> users { get; set; }

        public List<AnneeModels> years { get; set; }

    }
}