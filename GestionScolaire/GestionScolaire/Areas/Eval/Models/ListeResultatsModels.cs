using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionScolaire.Areas.Eval.Models
{
    public class ListeResultatsModels
    {
        [Display(Name = "Résultats")]
        public IList<ResultatModels> resultats { get; set; }

        public ListeResultatsModels()
        {
            resultats = new List<ResultatModels>();
        }

        public void add(ResultatModels r)
        {
            resultats.Add(r);
        }
    }
}