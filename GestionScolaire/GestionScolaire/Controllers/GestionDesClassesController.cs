using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionScolaire.Models;

namespace GestionScolaire.Controllers
{
    public class GestionDesClassesController : Controller
    {
        private Entities db = new Entities();

        // GET: /GestionDesClasses/
        public ActionResult Index()
        {
            return View();
        }

        #region Academie

        // GET: /GestionDesClasses/ReadAcademies
        public ActionResult ReadAcademies()
        {
            IList<AcademieModels> models = new List<AcademieModels>();
            using (AcademieRepository repository = new AcademieRepository())
            {
                IQueryable<Academies> a = repository.All();

                models = repository.All().Select(x => new AcademieModels
                {
                    id = x.Id,
                    name = x.Name
                }).ToList();
            }
            return View(models);
        }

        // GET: /GestionDesClasses/ReadAcademie/1122
        public ActionResult ReadAcademie(Guid id)
        {
            AcademieModels model;
            using (AcademieRepository repository = new AcademieRepository())
            {
                Academies a = repository.GetAcademieById(id);
                if (a == null){ 
                    return HttpNotFound();
                }
                model = new AcademieModels {
                    id = a.Id,
                    name = a.Name

                };   
            }
            return View(model);
        }

        // GET: /GestionDesClasses/CreateAcademie

        public ActionResult CreateAcademie()
        {
            return View();
        }

        // POST: /GestionDesClasses/CreateAcademie
        [HttpPost]
        public ActionResult CreateAcademie(AcademieModels model)
        {
            
            if (ModelState.IsValid)
            {
                using (AcademieRepository repository = new AcademieRepository())
                {
                    Academies a = new Academies
                    {
                        Id = Guid.NewGuid(),
                        Name = model.name
                    };

                    repository.Add(a);
                    repository.Save();

                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //
        // GET: /GestionDesClasses/Edit/5

        public ActionResult EditAcademie(Guid id)
        {
            AcademieModels model;
            using (AcademieRepository repository = new AcademieRepository())
            {
                Academies a = repository.GetAcademieById(id);
                if (a == null)
                {
                    return HttpNotFound();
                }
                model = new AcademieModels
                {
                    id = a.Id,
                    name = a.Name
                };
            }
            return View(model);
        }

        // POST: /GestionDesClasses/Edit/5

        [HttpPost]
        public ActionResult EditAcademie(AcademieModels model)
        {
            using (AcademieRepository repository = new AcademieRepository())
            {
                Academies a = repository.GetAcademieById(model.id);
                a.Name = model.name;

                if (ModelState.IsValid)
                {
                    repository.Save();
                }
                return RedirectToAction("Index");
            }

        }

        // GET: /GestionDesClasses/DeleteAcademie/5

        public ActionResult DeleteAcademie(Guid id)
        {
            AcademieModels model;
            using (AcademieRepository repository = new AcademieRepository())
            {
                Academies a = repository.GetAcademieById(id);
                if (a == null)
                {
                    return HttpNotFound();
                }
                model = new AcademieModels
                {
                    id = a.Id,
                    name = a.Name
                };
            }
           

            return View("DeleteAcademie",model);
        }

        // POST: /GestionDesClasses/DeleteAcademie/5
        [HttpPost, ActionName("DeleteAcademie")]
        public ActionResult DeleteAcademie(AcademieModels model)
        {
            using (AcademieRepository repository = new AcademieRepository())
            {
                repository.DeleteById(model.id);
                repository.Save();
            }
            return View("Index");
        }

        #endregion   
  
        #region Etablissement

        // GET: /GestionDesClasses/ReadEtablissements
        public ActionResult ReadEtablissements()
        {
            IList<EtablissementModels> models = new List<EtablissementModels>();
            using (EtablissementRepository repository = new EtablissementRepository())
            {
                IQueryable<Establishments> a = repository.All();

                models = repository.All().Select(x => new EtablissementModels
                {
                    id = x.Id,
                    name = x.Name,
                    address = x.Address,
                    postCode = x.PostCode,
                    town = x.Town,
                }).ToList();
            }
            return View(models);
        }

        // GET: /GestionDesClasses/ReadEtablissement/1122
        public ActionResult ReadEtablissement(Guid id)
        {
            EtablissementModels model;
            using (EtablissementRepository repository = new EtablissementRepository())
            {
                Establishments a = repository.GetEtablissementById(id);
                if (a == null){ 
                    return HttpNotFound();
                }
                model = new EtablissementModels {
                    id = a.Id,
                    name = a.Name,
                    address = a.Address,
                    postCode = a.PostCode,
                    town = a.Town,
                    userId = a.User_Id,
                    academieId = a.Academie_Id

                };   
            }
            return View(model);
        }

        // GET: /GestionDesClasses/CreateEtablissement

        public ActionResult CreateEtablissement()
        {
            return View();
        }

        // POST: /GestionDesClasses/CreateEtablissement
        [HttpPost]
        public ActionResult CreateEtablissement(EtablissementModels model)
        {
            if (ModelState.IsValid)
            {
                using (EtablissementRepository repository = new EtablissementRepository())
                {

                    Establishments a = new Establishments
                    {
                       Id = Guid.NewGuid(),
                       Name = model.name,
                       Address = model.address,
                       PostCode = model.postCode,
                       Town = model.town,
                       //User_Id = Guid.NewGuid(),
                       Academie_Id = model.academieId,

                      

                       // revoir avec les deja existant
                    };

                    repository.Add(a);
                    repository.Save();

                }
                return RedirectToAction("Index");
            }
           
            return View(model);
        }

        //
        // GET: /GestionDesClasses/Edit/5

        public ActionResult EditEtablissement(Guid id)
        {
            EtablissementModels model;
            using (EtablissementRepository repository = new EtablissementRepository())
            {
                Establishments a = repository.GetEtablissementById(id);
                if (a == null)
                {
                    return HttpNotFound();
                }
                model = new EtablissementModels
                {
                    id = a.Id,
                    name = a.Name,
                    address = a.Address,
                    postCode = a.PostCode,
                    town = a.Town,
                };
            }
            return View(model);
        }

        // POST: /GestionDesClasses/Edit/5

        [HttpPost]
        public ActionResult EditEtablissement(EtablissementModels model)
        {
            using (EtablissementRepository repository = new EtablissementRepository())
            {
                Establishments a = repository.GetEtablissementById(model.id);

                a.Name = model.name;
                a.Address = model.address;
                a.PostCode = model.postCode;
                a.Town = model.town;

                if (ModelState.IsValid)
                {
                    repository.Save();
                }
                return RedirectToAction("Index");
            }

        }

        // GET: /GestionDesClasses/DeleteEtablissement/5

        public ActionResult DeleteEtablissement(Guid id)
        {
            EtablissementModels model;
            using (EtablissementRepository repository = new EtablissementRepository())
            {
                Establishments a = repository.GetEtablissementById(id);
                if (a == null)
                {
                    return HttpNotFound();
                }
                model = new EtablissementModels
                {
                    id = a.Id,
                    name = a.Name,
                    address = a.Address,
                    postCode = a.PostCode,
                    town = a.Town,
                };
            }


            return View("DeleteEtablissement", model);
        }

        // POST: /GestionDesClasses/Etablissement/5
        [HttpPost, ActionName("DeleteEtablissement")]
        public ActionResult DeleteEtablissement(EtablissementModels model)
        {
            using (EtablissementRepository repository = new EtablissementRepository())
            {
                repository.DeleteById(model.id);
                repository.Save();
            }
            return View("Index");
        }

        #endregion     

        #region Classe

        // GET: /GestionDesClasses/ReadEtablissements
        public ActionResult ReadClasses()
        {
            IList<ClasseModels> models = new List<ClasseModels>();
            using (ClasseRepository repository = new ClasseRepository())
            {
                IQueryable<Classrooms> a = repository.All();

                models = repository.All().Select(x => new ClasseModels
                {
                    id = x.Id,
                    title = x.Title,
                    userId = x.User_Id,
                    yearId = x.Year_Id,
                    etablissementId = x.Establishment_Id,
                }).ToList();
            }
            return View(models);
        }

        // GET: /GestionDesClasses/ReadEtablissement/1122
        public ActionResult ReadClasse(Guid id)
        {
            ClasseModels model;
            using (ClasseRepository repository = new ClasseRepository())
            {
                Classrooms c= repository.GetClasseById(id);
                if (c == null)
                {
                    return HttpNotFound();
                }
                model = new ClasseModels
                {
                    id = c.Id,
                    title = c.Title,
                    userId = c.User_Id,
                    yearId = c.Year_Id,
                    etablissementId = c.Establishment_Id,

                };
            }
            return View(model);
        }

        // GET: /GestionDesClasses/CreateEtablissement

        public ActionResult CreateClasse()
        {
            return View();
        }

        // POST: /GestionDesClasses/CreateEtablissement
        [HttpPost]
        public ActionResult CreateClasse(ClasseModels model)
        {
            if (ModelState.IsValid)
            {
                using (ClasseRepository repository = new ClasseRepository())
                {

                    Classrooms a = new Classrooms
                    {
                        Id = Guid.NewGuid(),
                        Title = model.title,
                        User_Id = model.userId,
                        Year_Id = model.yearId,
                        Establishment_Id = model.etablissementId,



                        // revoir avec les deja existant
                    };

                    repository.Add(a);
                    repository.Save();

                }
                return RedirectToAction("Index");
            }

            return View(model);
        }

        //
        // GET: /GestionDesClasses/EditClasse/5

        public ActionResult EditClasse(Guid id)
        {
            ClasseModels model;
            using (ClasseRepository repository = new ClasseRepository())
            {
                Classrooms c = repository.GetClasseById(id);
                if (c == null)
                {
                    return HttpNotFound();
                }
                model = new ClasseModels
                {
                    id = c.Id,
                    title = c.Title,
                    userId = c.User_Id,
                    yearId = c.Year_Id,
                    etablissementId = c.Establishment_Id,
                };
            }
            return View(model);
        }

        // POST: /GestionDesClasses/EditClasse/5

        [HttpPost]
        public ActionResult EditClasse(ClasseModels model)
        {
            using (ClasseRepository repository = new ClasseRepository())
            {
                Classrooms a = repository.GetClasseById(model.id);

                a.Title = model.title;
                a.User_Id = model.userId;
                a.Year_Id = model.yearId;
                a.Establishment_Id = model.etablissementId;

                if (ModelState.IsValid)
                {
                    repository.Save();
                }
                return RedirectToAction("Index");
            }

        }

        // GET: /GestionDesClasses/DeleteClasse/5

        public ActionResult DeleteClasse(Guid id)
        {
            ClasseModels model;
            using (ClasseRepository repository = new ClasseRepository())
            {
                Classrooms c = repository.GetClasseById(id);
                if (c == null)
                {
                    return HttpNotFound();
                }
                model = new ClasseModels
                {
                    id = c.Id,
                    title = c.Title,
                    userId = c.User_Id,
                    yearId = c.Year_Id,
                    etablissementId = c.Establishment_Id,
                };
            }


            return View("DeleteClasse", model);
        }

        // POST: /GestionDesClasses/DeleteClasse/5
        [HttpPost, ActionName("DeleteClasse")]
        public ActionResult DeleteEtablissement(ClasseModels model)
        {
            using (ClasseRepository repository = new ClasseRepository())
            {
                repository.DeleteById(model.id);
                repository.Save();
            }
            return View("Index");
        }

        #endregion     
    }
    
    
}
