using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace GestionScolaire.Areas.GestionDesClasses.Models
{
    public class AcademieModels
    {
        [Display(Name = "Id de l'ancademie")]
        public Guid id { get; set; }

        [Display(Name = "Nom de l'academie")]
        public String name { get; set; }

    }
}