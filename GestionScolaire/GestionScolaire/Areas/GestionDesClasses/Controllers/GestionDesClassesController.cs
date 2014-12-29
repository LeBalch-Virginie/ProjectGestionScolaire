using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionScolaire.Models;
using GestionScolaire.Areas.GestionDesClasses.Models;
using GestionScolaire.Areas.Administration.Models;
using GestionScolaire.Areas.Eleves.Models;


namespace GestionScolaire.Areas.GestionDesClasses.Controllers
{
    public class GestionDesClassesController : Controller
    {

        // GET: /GestionDesClasses/
        public ActionResult Index()
        {
            return View();
        }

        private List<AcademieModels> getListAcademies(IQueryable<Academies> academies)
        {
            List<AcademieModels> ac = new List<AcademieModels>();
            foreach (var aca in academies)
            {
                AcademieModels a = new AcademieModels
                {
                    id = aca.Id,
                    name = aca.Name
                };
                ac.Add(a);
            }
            return ac;
        }

        private List<UserModels> getListUsers(IQueryable<Users> users)
        {
            List<UserModels> list = new List<UserModels>();
            foreach (var u in users)
            {
                UserModels a = new UserModels
                {
                    firstName = u.FirstName,
                    id = u.Id,
                    lastName = u.LastName,
                    mail = u.Mail,
                    password = u.Password,
                    userName = u.UserName
                };
                list.Add(a);
            }
            return list;
        }

        private List<AnneeModels> getListYears(IQueryable<Years> years)
        {
            List<AnneeModels> list = new List<AnneeModels>();
            foreach (var u in years)
            {
                AnneeModels a = new AnneeModels
                {
                    id = u.Id,
                    year = u.Year

                };
                list.Add(a);
            }
            return list;
        }

        private List<EtablissementModels> getListEtablissements(IQueryable<Establishments> etablissements)
        {
            List<EtablissementModels> list = new List<EtablissementModels>();
            foreach (var u in etablissements)
            {
                EtablissementModels a = new EtablissementModels
                {
                    id = u.Id,
                    name = u.Name,
                    address = u.Address,
                    postCode = u.PostCode,
                    town = u.Town,
                    userId = u.User_Id,
                    academieId = u.Academie_Id
                };
                list.Add(a);
            }
            return list;
        }

        private List<EleveModels> getListEleves(IQueryable<Pupils> pupils)
        {
            List<EleveModels> list = new List<EleveModels>();
            foreach (var u in pupils)
            {
                EleveModels a = new EleveModels
                {
                    id = u.Id,
                    birthdayDate = u.BirthdayDate,
                    classroomId = u.Classroom_Id,
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    levelId = u.Level_Id,
                    sexe = u.Sex,
                    tuteurId = u.Tutor_Id
                };
                list.Add(a);
            }
            return list;
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
                 IQueryable<Establishments> l = repository.GetEstablishmentById(id);
                if (a == null)
                {
                    return HttpNotFound();
                }
                model = new AcademieModels
                {
                    id = a.Id,
                    name = a.Name,
                    etablissements = getListEtablissements(l)
                };
            }
            return View(model);
        }

        // GET: /GestionDesClasses/CreateAcademie

        public ActionResult CreateAcademie()
        {
            AcademieModels model = new AcademieModels()
            {
                mode = -1
            };
            return View(model);
        }

        // POST: /GestionDesClasses/SearchAcademies
        [HttpPost]
        public ActionResult SearchAcademies(String query)
        {
            IList<AcademieModels> models = new List<AcademieModels>();
            using (AcademieRepository repository = new AcademieRepository())
            {
                models = repository.GetAcademiesByQuery(query).Select(x => new AcademieModels
                {
                    id = x.Id,
                    name = x.Name
                }).ToList();
            }
            return PartialView("_academiesList", models);
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
                return RedirectToAction("ReadAcademies");
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
                    mode = 0,
                    id = a.Id,
                    name = a.Name
                };
            }
            return View("CreateAcademie", model);
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
                return RedirectToAction("ReadAcademies");
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


            return View("DeleteAcademie", model);
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
                    town = x.Town                     
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
                    userId = a.User_Id,
                    academieId = a.Academie_Id,
                    userName = a.Users.UserName,
                    academieName = a.Academies.Name

                };
            }
            return View(model);
        }

        // GET: /GestionDesClasses/CreateEtablissement

        public ActionResult CreateEtablissement()
        {
            EtablissementModels model;
            using (EtablissementRepository repository = new EtablissementRepository())
            {
                IQueryable<Academies> academies = repository.GetAcademies();
                IQueryable<Users> users = repository.GetUsers();
                model = new EtablissementModels
                {
                    mode = -1,
                    academies = getListAcademies(academies),
                    users = getListUsers(users)
                };
            }
            return View(model);
        }

        // POST: /GestionDesClasses/SearchEtablissements
        [HttpPost]
        public ActionResult SearchEtablissements(String query)
        {
            IList<EtablissementModels> models = new List<EtablissementModels>();
            using (EtablissementRepository repository = new EtablissementRepository())
            {
                models = repository.GetEtablissementsByQuery(query).Select(x => new EtablissementModels
                {
                    id = x.Id,
                    name = x.Name,
                    address = x.Address,
                    postCode = x.PostCode,
                    town = x.Town
                }).ToList();
            }
            return PartialView("_etablissementsList", models);
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
                        User_Id = model.userId,
                        Academie_Id = model.academieId
                    };

                    repository.Add(a);
                    repository.Save();

                }
                return RedirectToAction("ReadEtablissements");
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
                IQueryable<Academies> academies = repository.GetAcademies();
                IQueryable<Users> users = repository.GetUsers();
                Establishments a = repository.GetEtablissementById(id);
                if (a == null)
                {
                    return HttpNotFound();
                }
                model = new EtablissementModels
                {
                    mode = 0,
                    id = a.Id,
                    name = a.Name,
                    address = a.Address,
                    postCode = a.PostCode,
                    town = a.Town,
                    academieId = a.Academie_Id,
                    userId = a.User_Id,
                    academies = getListAcademies(academies),
                    users = getListUsers(users)
                };
            }
            return View("CreateEtablissement", model);
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
                a.User_Id = model.userId;
                a.Academie_Id = model.academieId;

                if (ModelState.IsValid)
                {
                    repository.Save();
                }
                return RedirectToAction("ReadEtablissements");
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

        // GET: /GestionDesClasses/Classes
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
                    etablissementId = x.Establishment_Id
                }).ToList();
            }
            return View(models);
        }

        // GET: /GestionDesClasses/ReadClasse/1122
        public ActionResult ReadClasse(Guid id)
        {
            ClasseModels model;
            using (ClasseRepository repository = new ClasseRepository())
            {
                Classrooms c = repository.GetClasseById(id);
                //IQueryable<Users> l = repository.GetUserById(id);
                IQueryable<Pupils> l = repository.GetPupilsById(id);
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
                    userName = c.Users.UserName,
                    yearName = c.Years.Year,
                    etablissementName = c.Establishments.Name,
                    pupils = getListEleves(l)
                };
            }
            return View(model);
        }

        // GET: /GestionDesClasses/CreateClasse

        public ActionResult CreateClasse()
        {
            ClasseModels model;
            using (ClasseRepository repository = new ClasseRepository())
            {

                IQueryable<Users> users = repository.GetUsers();
                IQueryable<Years> years = repository.GetYears();
                IQueryable<Establishments> etablissements = repository.GetEtablissements();
                model = new ClasseModels
                {
                    mode = -1,
                    users = getListUsers(users),
                    years = getListYears(years),
                    etablissements = getListEtablissements(etablissements)
                };
            }
            return View(model);
        }

        // POST: /GestionDesClasses/SearchClasses
        [HttpPost]
        public ActionResult SearchClasses(String query)
        {
            IList<ClasseModels> models = new List<ClasseModels>();
            using (ClasseRepository repository = new ClasseRepository())
            {
                models = repository.GetClassesByQuery(query).Select(x => new ClasseModels
                {
                    id = x.Id,
                    title = x.Title,
                    userId = x.User_Id,
                    yearId = x.Year_Id,
                    etablissementId = x.Establishment_Id,
                }).ToList();
            }
            return PartialView("_classesList", models);
        }

        // POST: /GestionDesClasses/CreateClasse
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
                    };

                    repository.Add(a);
                    repository.Save();

                }
                return RedirectToAction("ReadClasses");
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
                IQueryable<Years> years = repository.GetYears();
                IQueryable<Users> users = repository.GetUsers();
                IQueryable<Establishments> etablissements = repository.GetEtablissements();
                Classrooms c = repository.GetClasseById(id);
                if (c == null)
                {
                    return HttpNotFound();
                }
                model = new ClasseModels
                {
                    mode = 0,
                    id = c.Id,
                    title = c.Title,
                    userId = c.User_Id,
                    yearId = c.Year_Id,
                    etablissementId = c.Establishment_Id,
                    users = getListUsers(users),
                    years = getListYears(years),
                    etablissements = getListEtablissements(etablissements)
                };
            }
            return View("CreateClasse", model);
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
                return RedirectToAction("ReadClasses");
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

        #region User

        // GET: /GestionDesClasses/ReadUsers
        public ActionResult ReadUsers()
        {
            IList<UserModels> models = new List<UserModels>();
            using (UserRepository repository = new UserRepository())
            {
                IQueryable<Users> a = repository.All();

                models = repository.All().Select(x => new UserModels
                {
                    id = x.Id,
                    userName = x.UserName,
                    password = x.Password,
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    mail = x.Mail
                }).ToList();
            }
            return View(models);
        }

        // GET: /GestionDesClasses/ReadUser/1122
        public ActionResult ReadUser(Guid id)
        {
            UserModels model;
            using (UserRepository repository = new UserRepository())
            {
                Users x = repository.GetUserById(id);
                if (x == null)
                {
                    return HttpNotFound();
                }
                model = new UserModels
                {
                    id = x.Id,
                    userName = x.UserName,
                    password = x.Password,
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    mail = x.Mail
                };
            }
            return View(model);
        }

        // GET: /GestionDesClasses/CreateUser

        public ActionResult CreateUser()
        {
            UserModels model = new UserModels()
            {
                mode = -1
            };
            return View(model);
        }

        // POST: /GestionDesClasses/SearchUsers
        [HttpPost]
        public ActionResult SearchUsers(String query)
        {
            IList<UserModels> models = new List<UserModels>();
            using (UserRepository repository = new UserRepository())
            {
                models = repository.GetUsersByQuery(query).Select(x => new UserModels
                {
                    id = x.Id,
                    userName = x.UserName,
                }).ToList();
            }
            return PartialView("_usersList", models);
        }

        // POST: /GestionDesClasses/CreateUser
        [HttpPost]
        public ActionResult CreateUser(UserModels model)
        {

            if (ModelState.IsValid)
            {
                using (UserRepository repository = new UserRepository())
                {
                    Users a = new Users
                    {
                        Id = Guid.NewGuid(),
                        UserName = model.userName,
                        Password = model.password,
                        FirstName = model.firstName,
                        LastName = model.lastName,
                        Mail = model.mail
                    };

                    repository.Add(a);
                    repository.Save();

                }
                return RedirectToAction("ReadUsers");
            }
            return View(model);
        }

        //
        // GET: /GestionDesClasses/Edit/5

        public ActionResult EditUser(Guid id)
        {
            UserModels model;
            using (UserRepository repository = new UserRepository())
            {
                Users x = repository.GetUserById(id);
                if (x == null)
                {
                    return HttpNotFound();
                }
                model = new UserModels
                {
                    mode = 0,
                    id = x.Id,
                    userName = x.UserName,
                    password = x.Password,
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    mail = x.Mail
                };
            }
            return View("CreateUser", model);
        }

        // POST: /GestionDesClasses/Edit/5

        [HttpPost]
        public ActionResult EditUser(UserModels model)
        {
            using (UserRepository repository = new UserRepository())
            {
                Users a = repository.GetUserById(model.id);
                a.UserName = model.userName;
                a.Password = model.password;
                a.FirstName = model.firstName;
                a.LastName = model.lastName;
                a.Mail = model.mail;

                if (ModelState.IsValid)
                {
                    repository.Save();
                }
                return RedirectToAction("ReadUsers");
            }

        }

        // GET: /GestionDesClasses/DeleteUser/5

        public ActionResult DeleteUser(Guid id)
        {
            UserModels model;
            using (UserRepository repository = new UserRepository())
            {
                Users x = repository.GetUserById(id);
                if (x == null)
                {
                    return HttpNotFound();
                }
                model = new UserModels
                {
                    id = x.Id,
                    userName = x.UserName,
                    password = x.Password,
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    mail = x.Mail
                };
            }


            return View("DeleteUser", model);
        }

        // POST: /GestionDesClasses/DeleteUser/5
        [HttpPost, ActionName("DeleteUser")]
        public ActionResult DeleteAcademie(UserModels model)
        {
            using (UserRepository repository = new UserRepository())
            {
                repository.DeleteById(model.id);
                repository.Save();
            }
            return View("Index");
        }

        #endregion
    }


}
