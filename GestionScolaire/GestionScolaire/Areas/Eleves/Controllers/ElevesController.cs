using GestionScolaire.Areas.Eleves.Models;
using GestionScolaire.Areas.Administration.Models;
using GestionScolaire.Areas.GestionDesClasses.Models;
using GestionScolaire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;
using GestionScolaire.Areas.Eval.Models;

namespace GestionScolaire.Areas.Eleves.Controllers
{
    public class ElevesController : Controller
    {

        private List<ClasseModels> getListClasses(IQueryable<Classrooms> classrooms)
        {
            List<ClasseModels> ac = new List<ClasseModels>();
            foreach (var aca in classrooms)
            {
                ClasseModels c = new ClasseModels
                {
                    id = aca.Id,
                    title = aca.Title,
                    userId = aca.User_Id,
                    yearId = aca.Year_Id,
                    etablissementId = aca.Establishment_Id,
                };
                ac.Add(c);
            }
            return ac;
        }

        private List<TuteurModels> getListTuteurs(IQueryable<Tutors> tuteurs)
        {
            List<TuteurModels> ac = new List<TuteurModels>();
            foreach (var aca in tuteurs)
            {
                TuteurModels x = new TuteurModels
                {
                    id = aca.Id,
                    firstName = aca.FirstName,
                    lastName = aca.LastName,
                    mail = aca.Mail,
                    postCode = aca.PostCode,
                    comment = aca.Comment,
                    town = aca.Town,
                    tel = aca.Tel,
                    address = aca.Address,
                };
                ac.Add(x);
            }
            return ac;
        }

        private List<NiveauModels> getListNiveaux(IQueryable<Levels> niveaux)
        {
            List<NiveauModels> ac = new List<NiveauModels>();
            foreach (var aca in niveaux)
            {
                NiveauModels x = new NiveauModels
                {
                    id = aca.Id,
                    title = aca.Title,
                    cycleId = aca.Cycle_Id,
                };
                ac.Add(x);
            }
            return ac;
        }

        private List<ResultatModels> getListResultats(IQueryable<Results> resultats)
        {
            List<ResultatModels> r = new List<ResultatModels>();
            foreach (var res in resultats)
            {
                ResultatModels x = new ResultatModels
                {
                    id = res.Id,
                    evaluationId = res.Evaluation_Id,
                    note = res.Note,
                    pupilId = res.Pupil_Id,
                };
                r.Add(x);
            }
            return r;
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

        private List<EvaluationModels> getListEvaluations(IQueryable<Evaluations> evaluations)
        {
            List<EvaluationModels> list = new List<EvaluationModels>();
            foreach (var u in evaluations)
            {
                EvaluationModels a = new EvaluationModels
                {
                    id = u.Id,
                    classroomId = u.Classroom_Id,
                    date = u.Date,
                    classroomName = u.Classrooms.Title,
                    periodId = u.Period_Id,
                    periodBegin = u.Periods.Begin,
                    periodEnd = u.Periods.End,
                    totalPoint = u.TotalPoint,
                    userId = u.User_Id,
                    userName = u.Users.UserName
                };
                list.Add(a);
            }
            return list;
        }

        // GET: /Eleves/Eleves/

        public ActionResult Index()
        {
            return View();
        }

        #region Tuteurs

        // GET: /Eleves/ReadTuteurs
        public ActionResult ReadTuteurs()
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
                }).ToList();
            }
            return View(models);
        }

        public ActionResult ReadTuteur(Guid id)
        {
            TuteurModels model;
            
            using (TuteurRepository repository = new TuteurRepository())
            {
                Tutors x = repository.GetTutorById(id);
                IQueryable<Pupils> l = repository.GetPupilsById(id);
                if (x == null)
                {
                    return HttpNotFound();
                }
                model = new TuteurModels
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
                    pupils = getListEleves(l)

                };
            }
            return View(model);
        }

        // GET: /Eleves/CreateTuteur
        public ActionResult CreateTuteur()
        {
            TuteurModels model = new TuteurModels()
            {
                mode = -1
            };
            return View(model);
        }

        // POST: /GestionDesClasses/SearchEleves
        [HttpPost]
        public ActionResult SearchTuteurs(String query)
        {
            IList<TuteurModels> models = new List<TuteurModels>();
            using (TuteurRepository repository = new TuteurRepository())
            {
                models = repository.GetTuteursByQuery(query).Select(x => new TuteurModels
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
            return PartialView("_tuteursList", models);
        }

        // POST: /Eleves/CreateTuteur
        [HttpPost]
        public ActionResult CreateTuteur(TuteurModels model)
        {

            if (ModelState.IsValid)
            {
                using (TuteurRepository repository = new TuteurRepository())
                {
                    Tutors a = new Tutors
                    {
                        Id = Guid.NewGuid(),
                        FirstName = model.firstName,
                        LastName = model.lastName,
                        Mail = model.mail,
                        PostCode = model.postCode,
                        Comment = model.comment,
                        Town = model.town,
                        Tel = model.tel,
                        Address = model.address,
                        // eleves = 
                    };

                    repository.Add(a);
                    repository.Save();

                }
                return RedirectToAction("ReadTuteurs");
            }
            return View(model);
        }

        public ActionResult EditTuteur(Guid id)
        {
            TuteurModels model;
            using (TuteurRepository repository = new TuteurRepository())
            {
                Tutors x = repository.GetTutorById(id);
                if (x == null)
                {
                    return HttpNotFound();
                }
                model = new TuteurModels
                {
                    mode = 0,
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
                };
            }
            return View("CreateTuteur", model);
        }

        // POST: /Eleves/Edit/5

        [HttpPost]
        public ActionResult EditTuteur(TuteurModels model)
        {
            using (TuteurRepository repository = new TuteurRepository())
            {
                Tutors x = repository.GetTutorById(model.id);
                x.FirstName = model.firstName;
                x.LastName = model.lastName;
                x.Mail = model.mail;
                x.PostCode = model.postCode;
                x.Comment = model.comment;
                x.Town = model.town;
                x.Tel = model.tel;
                x.Address = model.address;
                // eleves = 

                if (ModelState.IsValid)
                {
                    repository.Save();
                }
                return RedirectToAction("ReadTuteurs");
            }

        }

        public ActionResult DeleteTuteur(Guid id)
        {
            TuteurModels model;
            using (TuteurRepository repository = new TuteurRepository())
            {
                Tutors x = repository.GetTutorById(id);
                if (x == null)
                {
                    return HttpNotFound();
                }
                model = new TuteurModels
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
                };
            }


            return View("DeleteTuteur", model);
        }

        // POST: /Eleves/DeleteTuteur/5
        [HttpPost, ActionName("DeleteTuteur")]
        public ActionResult DeleteTuteur(TuteurModels model)
        {
            using (TuteurRepository repository = new TuteurRepository())
            {
                repository.DeleteById(model.id);
                repository.Save();
            }
            return View("Index");
        }

        #endregion

        //////////////////////////////////////////////////////////////

        // GET: /Eleves/ReadEleves
        public ActionResult ReadEleves()
        {
            IList<EleveModels> models = new List<EleveModels>();
            using (EleveRepository repository = new EleveRepository())
            {
                IQueryable<Pupils> a = repository.All();

                models = repository.All().Select(x => new EleveModels
                {
                    id = x.Id,
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    sexe = x.Sex,
                    birthdayDate = x.BirthdayDate,
                    tuteurId = x.Tutor_Id,
                    classroomId = x.Classroom_Id,
                    levelId = x.Level_Id
                    // tuteurs = 
                    // classroom =
                    // level =
                    // result =
                }).ToList();
            }
            return View(models);
        }

        public ActionResult ReadEleve(Guid id)
        {
            EleveModels model;
            using (EleveRepository repository = new EleveRepository())
            {
                Pupils x = repository.GetPupilById(id);
                IQueryable<Tutors> t = repository.GetTutors();
                IQueryable<Results> r = repository.GetResultatsByPupilId(id);
                IQueryable<Evaluations> e = repository.GetEvaluations();
                if (x == null)
                {
                    return HttpNotFound();
                }
                model = new EleveModels
                {
                    id = x.Id,
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    sexe = x.Sex,
                    birthdayDate = x.BirthdayDate,
                    tuteurId = x.Tutor_Id,
                    classroomId = x.Classroom_Id,
                    levelId = x.Level_Id,
                    tuteurName = x.Tutors.LastName,
                    classTitle = x.Classrooms.Title,
                    niveauName = x.Levels.Title,
                    resultats = getListResultats(r),
                    evaluations = getListEvaluations(e)
                };
            }
            return View(model);
        }

        // GET: /Eleves/CreateEleve
        public ActionResult CreateEleve(Guid? classe, Guid? level, Guid? tuteur)
        {
            EleveModels model;
            using (EleveRepository repository = new EleveRepository())
            {

                IQueryable<Tutors> tuteurs = repository.GetTutors();
                IQueryable<Classrooms> classes = repository.GetClasses();
                IQueryable<Levels> niveaux = repository.GetNiveaux();
                model = new EleveModels
                {
                    mode = -1,
                    tuteurs = getListTuteurs(tuteurs),
                    classes = getListClasses(classes),
                    niveaux = getListNiveaux(niveaux),  
                };
                if (classe != null)
                {
                    model.classroomId = (Guid) classe;
                }
                if (level != null)
                {
                    model.levelId = (Guid) level;
                }
                if (tuteur != null)
                {
                    model.tuteurId = (Guid) tuteur;
                }
               
            }
            return View(model);
        }

        // POST: /GestionDesClasses/SearchEleves
        [HttpPost]
        public ActionResult SearchEleves(String query)
        {
            IList<EleveModels> models = new List<EleveModels>();
            using (EleveRepository repository = new EleveRepository())
            {
                IQueryable<Pupils> a = repository.All();

                models = repository.GetElevesByQuery(query).Select(x => new EleveModels
                {
                    id = x.Id,
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    sexe = x.Sex,
                    birthdayDate = x.BirthdayDate,
                    tuteurId = x.Tutor_Id,
                    classroomId = x.Classroom_Id,
                    levelId = x.Level_Id
                    // tuteurs = 
                    // classroom =
                    // level =
                    // result =
                }).ToList();
            }
            return PartialView("_elevesList", models);
        }

        // POST: /Eleves/CreateEleve
        [HttpPost]
        public ActionResult CreateEleve(EleveModels model)
        {

            if (ModelState.IsValid)
            {
                using (EleveRepository repository = new EleveRepository())
                {
                    Pupils a = new Pupils
                    {
                        Id = Guid.NewGuid(),
                        State = short.MaxValue,
                        FirstName = model.firstName,
                        LastName = model.lastName,
                        Sex = model.sexe,
                        BirthdayDate = model.birthdayDate,
                        Tutor_Id = model.tuteurId,
                        Classroom_Id = model.classroomId,
                        Level_Id = model.levelId
                        // tuteurs = 
                        // classroom =
                        // level =
                        // result =
                    };

                    repository.Add(a);
                    repository.Save();

                }
                return RedirectToAction("ReadEleves");
            }
            return View(model);
        }

        public ActionResult EditEleve(Guid id)
        {
            EleveModels model;
            using (EleveRepository repository = new EleveRepository())
            {

                IQueryable<Tutors> tuteurs = repository.GetTutors();
                IQueryable<Classrooms> classes = repository.GetClasses();
                IQueryable<Levels> niveaux = repository.GetNiveaux();
                Pupils x = repository.GetPupilById(id);
                model = new EleveModels
                {
                    mode = 0,
                    state = short.MaxValue,
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    sexe = x.Sex,
                    birthdayDate = x.BirthdayDate,
                    tuteurId = x.Tutor_Id,
                    classroomId = x.Classroom_Id,
                    levelId = x.Level_Id,
                    tuteurs = getListTuteurs(tuteurs),
                    classes = getListClasses(classes),
                    niveaux = getListNiveaux(niveaux)
                };
            }
            return View("CreateEleve", model);
        }

        // POST: /Eleves/Edit/5

        [HttpPost]
        public ActionResult EditEleve(EleveModels model)
        {
            using (EleveRepository repository = new EleveRepository())
            {
                Pupils x = repository.GetPupilById(model.id);
                x.State = short.MaxValue;
                x.FirstName = model.firstName;
                x.LastName = model.lastName;
                x.Sex = model.sexe;
                x.BirthdayDate = model.birthdayDate;
                x.Tutor_Id = model.tuteurId;
                x.Classroom_Id = model.classroomId;
                x.Level_Id = model.levelId;
                // eleves = 

                if (ModelState.IsValid)
                {
                    repository.Save();
                }
                return RedirectToAction("ReadEleves");
            }

        }

        public ActionResult DeleteEleve(Guid id)
        {
            EleveModels model;
            using (EleveRepository repository = new EleveRepository())
            {
                Pupils x = repository.GetPupilById(id);
                if (x == null)
                {
                    return HttpNotFound();
                }
                model = new EleveModels
                {
                    id = x.Id,
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    sexe = x.Sex,
                    birthdayDate = x.BirthdayDate,
                    tuteurId = x.Tutor_Id,
                    classroomId = x.Classroom_Id,
                    levelId = x.Level_Id
                    // tuteurs = 
                    // classroom =
                    // level =
                    // result =
                };
            }


            return View("DeleteEleve", model);
        }

        // POST: /Eleves/DeleteEleve/5
        [HttpPost, ActionName("DeleteEleve")]
        public ActionResult DeleteEleve(EleveModels model)
        {
            using (EleveRepository repository = new EleveRepository())
            {
                repository.DeleteById(model.id);
                repository.Save();
            }
            return View("Index");
        }



        // EXPORT EXCEL
        public ActionResult ExportExcel()
        {
            GridView gv = new GridView();

            IList<EleveModels> models = new List<EleveModels>();
            using (EleveRepository repository = new EleveRepository())
            {
                IQueryable<Pupils> a = repository.All();

                gv.DataSource = repository.All().Select(x => new EleveModels
                {
                    id = x.Id,
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    sexe = x.Sex,
                    birthdayDate = x.BirthdayDate,
                    tuteurId = x.Tutor_Id,
                    classroomId = x.Classroom_Id,
                    levelId = x.Level_Id
                }).ToList();
            }

            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Liste_élèves.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return RedirectToAction("ReadEleves");
        }
    }

}
