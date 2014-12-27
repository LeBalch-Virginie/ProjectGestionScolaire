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
            return View(model);
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
        public ActionResult DeleteTuteur(EvaluationModels model)
        {
            using (EvaluationRepository repository = new EvaluationRepository())
            {
                repository.DeleteById(model.id);
                repository.Save();
            }
            return View("Index");
        }

        #endregion

    }
}
