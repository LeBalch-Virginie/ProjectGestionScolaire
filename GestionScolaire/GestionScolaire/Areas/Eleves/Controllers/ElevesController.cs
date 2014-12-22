using GestionScolaire.Areas.Eleves.Models;
using GestionScolaire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionScolaire.Areas.Eleves.Controllers
{
    public class ElevesController : Controller
    {
        //
        // GET: /Eleves/Eleves/

        public ActionResult Index()
        {
            return View();
        }

        // GET: /Eleves/ReadEleves
        public ActionResult ReadEleves()
        {
            IList<TuteurModels> models = new List<TuteurModels>();
            using (TuteurRepository repository = new TuteurRepository())
            {
                IQueryable<Tutors> a = repository.All();

                models = repository.All().Select(x => new TuteurModels
                {
                    id = x.Id,
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    mail = x.Mail,
                    postCode = x.PostCode,
                    comment = x.Comment,
                    town = x.Town,
                    tel = x.Tel,
                    address = x.Address,
                   // eleves = 
                }).ToList();
            }
            return View(models);
        }
    }
}
