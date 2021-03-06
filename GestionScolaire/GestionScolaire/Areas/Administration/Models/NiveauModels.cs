﻿using GestionScolaire.Areas.Eleves.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionScolaire.Areas.Administration.Models
{
    public class NiveauModels
    {
        [Display(Name = "Id du niveau")]
        public Guid id { get; set; }

        [Display(Name = "Titre du niveau")]
        [StringLength(50)]
        [Required]
        public String title { get; set; }

        [Display(Name = "Id du cycle auquel il appartient")]
        public Guid cycleId { get; set; }

        public String cycleTitle { get; set; }

        public List<EleveModels> eleves { get; set; }
    }
}