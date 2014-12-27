using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionScolaire.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modifiez ce modèle pour dynamiser votre application ASP.NET MVC.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Votre page de description d’application.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Votre page de contact.";

            return View();
        }

        public ActionResult Administration()
        {
            ViewBag.Message = "Votre page d'administration.";

            return View();
        }

        public ActionResult GestionDesClasses()
        {
            ViewBag.Message = "Votre page gestion des classes .";

            return View();
        }

        public ActionResult Eleves()
        {
            ViewBag.Message = "Votre page gestion des élèves.";

            return View();
        }


        public ActionResult Eval()
        {
            ViewBag.Message = "Votre page gestion des évaluations.";

            return View();
        }

    }
}
