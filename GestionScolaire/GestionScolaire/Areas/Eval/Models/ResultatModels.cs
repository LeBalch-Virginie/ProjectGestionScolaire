﻿using GestionScolaire.Areas.Eleves.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionScolaire.Areas.Eval.Models
{
    public class ResultatModels
    {
        [Display(Name = "Id du résultat")]
        public Guid id { get; set; }

        [Display(Name = "Evaluation")]
        public Guid evaluationId { get; set; }

        [Display(Name = "Elève")]
        public Guid pupilId { get; set; }

        [Display(Name = "Note")]
        public double note { get; set; }

        public List<EleveModels> eleves { get; set; }

        public List<EvaluationModels> evaluations { get; set; }

        public int mode { get; set; }
    }
}