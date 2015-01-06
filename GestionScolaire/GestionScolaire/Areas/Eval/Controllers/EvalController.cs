using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionScolaire.Areas.Eval.Models;
using GestionScolaire.Areas.Eleves.Models;
using GestionScolaire.Areas.Administration.Models;
using GestionScolaire.Areas.GestionDesClasses.Models;
using GestionScolaire.Models;

namespace GestionScolaire.Areas.Eval.Controllers
{
    public class EvalController : Controller
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

        private List<PeriodeModels> getListPeriodes(IQueryable<Periods> periodes)
        {
            List<PeriodeModels> ac = new List<PeriodeModels>();
            foreach (var aca in periodes)
            {
                PeriodeModels c = new PeriodeModels
                {
                    id = aca.Id,
                    begin = aca.Begin,
                    end = aca.End,
                    yearId = aca.Year_Id
                };
                ac.Add(c);
            }
            return ac;
        }

        private List<UserModels> getListUsers(IQueryable<Users> users)
        {
            List<UserModels> ac = new List<UserModels>();
            foreach (var aca in users)
            {
                UserModels c = new UserModels
                {
                    id = aca.Id,
                    userName = aca.UserName,
                    password = aca.Password,
                    firstName = aca.FirstName,
                    lastName = aca.LastName,
                    mail = aca.Mail
                };
                ac.Add(c);
            }
            return ac;
        }

        private List<EleveModels> getListPupils(IQueryable<Pupils> pupils)
        {
            List<EleveModels> ac = new List<EleveModels>();
            foreach (var aca in pupils)
            {
                EleveModels c = new EleveModels
                {
                    id = aca.Id,
                    birthdayDate = aca.BirthdayDate,
                    classroomId = aca.Classroom_Id,
                    firstName = aca.FirstName,
                    lastName = aca.LastName,
                    levelId = aca.Level_Id,
                    sexe = aca.Sex,
                    tuteurId = aca.Tutor_Id
                };
                ac.Add(c);
            }
            return ac;
        }

        private List<EvaluationModels> getListEvaluations(IQueryable<Evaluations> evals)
        {
            List<EvaluationModels> ev = new List<EvaluationModels>();
            foreach (var eval in evals)
            {
                EvaluationModels c = new EvaluationModels
                {
                    id = eval.Id,
                    classroomId = eval.Classroom_Id,
                    date = eval.Date,
                    periodId = eval.Period_Id,
                    userId = eval.User_Id,
                    totalPoint = eval.TotalPoint
                };
                ev.Add(c);
            }
            return ev;
        }

        private List<EleveModels> getListEleves(IQueryable<Pupils> pupils)
        {
            List<EleveModels> l = new List<EleveModels>();
            foreach (var p in pupils)
            {
                EleveModels c = new EleveModels
                {
                    id = p.Id,
                    firstName = p.FirstName,
                    lastName = p.LastName,
                    birthdayDate = p.BirthdayDate,
                    classroomId = p.Classroom_Id,
                    levelId = p.Level_Id,
                    sexe = p.Sex,
                    tuteurId = p.Tutor_Id
                };
                l.Add(c);
            }
            return l;
        }

        private List<ResultatModels> getListResultats(IQueryable<Results> results)
        {
            List<ResultatModels> l = new List<ResultatModels>();
            foreach (var r in results)
            {
                ResultatModels c = new ResultatModels
                {
                    evaluationId = r.Evaluation_Id,
                    id = r.Id,
                    note = r.Note,
                    pupilId = r.Pupil_Id
                };
                l.Add(c);
            }
            return l;
        }


        //
        // GET: /Eval/Eval/

        public ActionResult Index()
        {
            return View();
        }

        #region Evaluations

        // GET: /Eval/ReadEvaluations
        public ActionResult ReadEvaluations()
        {
            IList<EvaluationModels> models = new List<EvaluationModels>();
            using (EvaluationRepository repository = new EvaluationRepository())
            {
                IQueryable<Evaluations> a = repository.All();

                models = repository.All().Select(x => new EvaluationModels
                {
                    id = x.Id,
                    classroomId = x.Classroom_Id,
                    userId = x.User_Id,
                    periodId = x.Period_Id,
                    date = x.Date,
                    totalPoint = x.TotalPoint,
                }).ToList();
            }
            return View(models);
        }

        public ActionResult ReadEvaluation(Guid id)
        {
            EvaluationModels model;
            using (EvaluationRepository repository = new EvaluationRepository())
            {
                Evaluations x = repository.GetEvaluationById(id);
                if (x == null)
                {
                    return HttpNotFound();
                }
                model = new EvaluationModels
                {
                    id = x.Id,
                    classroomId = x.Classroom_Id,
                    userId = x.User_Id,
                    periodId = x.Period_Id,
                    date = x.Date,
                    totalPoint = x.TotalPoint,
                    classroomName = x.Classrooms.Title,
                    userName = x.Users.UserName,
                    periodName = x.Periods.Begin

                };
            }
            return View(model);
        }

        // GET: /Eval/CreateEvaluation
        public ActionResult CreateEvaluation()
        {
            EvaluationModels model;
            using (EvaluationRepository repository = new EvaluationRepository())
            {

                IQueryable<Periods> periodes = repository.GetPeriodes();
                IQueryable<Classrooms> classes = repository.GetClasses();
                IQueryable<Users> users = repository.GetUsers();
                model = new EvaluationModels
                {
                    mode = -1,
                    periodes = getListPeriodes(periodes),
                    classes = getListClasses(classes),
                    users = getListUsers(users)
                };
            }
            return View(model);
        }

        // POST: /Eval/CreateEvaluation
        [HttpPost]
        public ActionResult CreateEvaluation(EvaluationModels model)
        {
            if (ModelState.IsValid)
            {
                using (EvaluationRepository repository = new EvaluationRepository())
                {
                    Evaluations a = new Evaluations
                    {
                        Id = Guid.NewGuid(),
                        Classroom_Id = model.classroomId,
                        User_Id = model.userId,
                        Period_Id = model.periodId,
                        Date = model.date,
                        TotalPoint = model.totalPoint,
                    };

                    repository.Add(a);
                    repository.Save();

                }
                return RedirectToAction("ReadEvaluations");
            }
            return View(model);
        }

        public ActionResult EditEvaluation(Guid id)
        {
            EvaluationModels model;
            using (EvaluationRepository repository = new EvaluationRepository())
            {
                Evaluations x = repository.GetEvaluationById(id);
                IQueryable<Periods> periodes = repository.GetPeriodes();
                IQueryable<Classrooms> classes = repository.GetClasses();
                IQueryable<Users> users = repository.GetUsers();
                if (x == null)
                {
                    return HttpNotFound();
                }
                model = new EvaluationModels
                {
                    mode = 0,
                    id = x.Id,
                    classroomId = x.Classroom_Id,
                    userId = x.User_Id,
                    periodId = x.Period_Id,
                    date = x.Date,
                    totalPoint = x.TotalPoint,
                    periodes = getListPeriodes(periodes),
                    classes = getListClasses(classes),
                    users = getListUsers(users)
                };
            }
            return View("CreateEvaluation", model);
        }

        // POST: /Eval/Edit/5

        [HttpPost]
        public ActionResult EditEvaluation(EvaluationModels model)
        {
            using (EvaluationRepository repository = new EvaluationRepository())
            {
                Evaluations x = repository.GetEvaluationById(model.id);
                    x.Classroom_Id = model.classroomId;
                    x.User_Id = model.userId;
                    x.Period_Id = model.periodId;
                    x.Date = model.date;
                    x.TotalPoint = model.totalPoint;

                if (ModelState.IsValid)
                {
                    repository.Save();
                }
                return RedirectToAction("ReadEvaluations");
            }

        }

        public ActionResult DeleteEvaluation(Guid id)
        {
            EvaluationModels model;
            using (EvaluationRepository repository = new EvaluationRepository())
            {
                Evaluations x = repository.GetEvaluationById(id);
                if (x == null)
                {
                    return HttpNotFound();
                }
                model = new EvaluationModels
                {
                    id = x.Id,
                    classroomId = x.Classroom_Id,
                    userId = x.User_Id,
                    periodId = x.Period_Id,
                    date = x.Date,
                    totalPoint = x.TotalPoint,
                };
            }


            return View("DeleteEvaluation", model);
        }

        // POST: /Eleves/DeleteEvaluation/5
        [HttpPost, ActionName("DeleteEvaluation")]
        public ActionResult DeleteEvaluation(EvaluationModels model)
        {
            using (EvaluationRepository repository = new EvaluationRepository())
            {
                repository.DeleteById(model.id);
                repository.Save();
            }
            return View("Index");
        }

        #endregion


        #region Resultats



        public ActionResult SaisirResultats(Guid idEval)
        {
            ListeResultatsModels model = new ListeResultatsModels();
            using (EvaluationRepository repo = new EvaluationRepository())
            {
                Evaluations e = repo.GetEvaluationById(idEval);
                if (e == null)
                {
                    return HttpNotFound();
                }
                IQueryable<Pupils> pupils = repo.GetPupilsByClassroom(repo.GetClassroomId(e));
                EvaluationModels m = new EvaluationModels
                {
                    id = e.Id,
                    classroomId = e.Classroom_Id,
                    eleves = getListPupils(pupils)
                };

                foreach (var eleve in m.eleves)
                {
                    ResultatModels r = new ResultatModels
                    {
                        pupilId = eleve.id,
                        pupilName = eleve.firstName + " " + eleve.lastName,
                        evaluationId = m.id
                    };
                    model.resultats.Add(r);
                }

            }
            return View(model);
        }

        [HttpPost]
        public ActionResult SaisirResultats(ListeResultatsModels model)
        {
            if (ModelState.IsValid) 
            {
                foreach (var resultat in model.resultats)
                {
                    using (ResultatRepository repository = new ResultatRepository())
                    {
                        Results r = new Results
                        {
                            Id = Guid.NewGuid(),
                            Pupil_Id = resultat.pupilId,
                            Note = resultat.note,
                            Evaluation_Id = resultat.evaluationId
                        };

                        repository.Add(r);
                        repository.Save();

                    }
                    
                }
                return RedirectToAction("ReadEvaluations");
            }
            return View(model);
        }

        // GET: /Eval/ReadResultats
        public ActionResult ReadResultats()
        {
            IList<ResultatModels> models = new List<ResultatModels>();
            using (ResultatRepository repository = new ResultatRepository())
            {
                IQueryable<Results> a = repository.All();

                models = repository.All().Select(x => new ResultatModels
                {
                    id = x.Id,
                    evaluationId = x.Evaluation_Id,
                    note = x.Note,
                    pupilId = x.Pupil_Id
                }).ToList();
            }
            return View(models);
        }

        public ActionResult ReadResultat(Guid id)
        {
            ResultatModels model;
            using (ResultatRepository repository = new ResultatRepository())
            {
                Results x = repository.GetResultById(id);
                if (x == null)
                {
                    return HttpNotFound();
                }
                model = new ResultatModels
                {
                    id = x.Id,
                    evaluationId = x.Evaluation_Id,
                    note = x.Note,
                    pupilId = x.Pupil_Id
                };
            }
            return View(model);
        }

        // GET: /Eval/CreateResultat
        public ActionResult CreateResultat()
        {
            ResultatModels model;
            using (ResultatRepository repository = new ResultatRepository())
            {

                IQueryable<Evaluations> evaluations = repository.GetEvaluations();
                IQueryable<Pupils> pupils = repository.GetEleves();
                model = new ResultatModels
                {
                    mode = -1,                    
                    eleves = getListEleves(pupils),
                    evaluations = getListEvaluations(evaluations)
                };
            }
            return View(model);
        }

        // POST: /Eval/CreateResultat
        [HttpPost]
        public ActionResult CreateResultat(ResultatModels model)
        {
            if (ModelState.IsValid)
            {
                using (ResultatRepository repository = new ResultatRepository())
                {
                    Results a = new Results
                    {
                        Id = Guid.NewGuid(),
                        Evaluation_Id = model.evaluationId,
                        Pupil_Id = model.pupilId,
                        Note = model.note
                    };

                    repository.Add(a);
                    repository.Save();

                }
                return RedirectToAction("ReadEvaluations");
            }
            return View(model);
        }

        public ActionResult EditResultat(Guid id)
        {
            ResultatModels model;
            using (ResultatRepository repository = new ResultatRepository())
            {
                Results x = repository.GetResultById(id);
                IQueryable<Evaluations> evaluations = repository.GetEvaluations();
                IQueryable<Pupils> pupils = repository.GetEleves();
                if (x == null)
                {
                    return HttpNotFound();
                }
                model = new ResultatModels
                {
                    mode = 0,
                    id = x.Id,
                    evaluationId = x.Evaluation_Id,
                    note = x.Note,
                    pupilId = x.Pupil_Id
                };
            }
            return View("CreateResultat", model);
        }

        // POST: /Eval/Edit/5

        [HttpPost]
        public ActionResult EditResultat(ResultatModels model)
        {
            using (ResultatRepository repository = new ResultatRepository())
            {
                Results x = repository.GetResultById(model.id);
                x.Evaluation_Id = model.evaluationId;
                x.Note = model.note;
                x.Pupil_Id = model.pupilId;

                if (ModelState.IsValid)
                {
                    repository.Save();
                }
                return RedirectToAction("ReadResultats");
            }

        }

        public ActionResult DeleteResultat(Guid id)
        {
            ResultatModels model;
            using (ResultatRepository repository = new ResultatRepository())
            {
                Results x = repository.GetResultById(id);
                if (x == null)
                {
                    return HttpNotFound();
                }
                model = new ResultatModels
                {
                    id = x.Id,
                    evaluationId = x.Evaluation_Id,
                    note = x.Note,
                    pupilId = x.Pupil_Id
                };
            }


            return View("DeleteResultat", model);
        }

        // POST: /Eleves/DeleteResultat/5
        [HttpPost, ActionName("DeleteResultat")]
        public ActionResult DeleteResultat(ResultatModels model)
        {
            using (ResultatRepository repository = new ResultatRepository())
            {
                repository.DeleteById(model.id);
                repository.Save();
            }
            return View("Index");
        }

        #endregion
    }
}
