using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionScolaire.Models
{
    public class CycleModels
    {
        [Display(Name = "Id du cycle")]
        public Guid id { get; set; }

        [Display(Name = "Titre du cycle")]
        public String title { get; set; }
    }
}