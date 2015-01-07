using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionScolaire.Areas.Administration.Models;
using GestionScolaire.Models;
using GestionScolaire.Areas.GestionDesClasses.Models;
using GestionScolaire.Areas.Eval.Models;
using GestionScolaire.Areas.Eleves.Models;

namespace GestionScolaire.Areas.Administration.Controllers
{
    public class AdministrationController : Controller
    {
        private List<NiveauModels> getListNiveau(IQueryable<Levels> levels)
        {
            List<NiveauModels> niveaux = new List<NiveauModels>();
            foreach (var level in levels)
            {
                NiveauModels niveau = new NiveauModels
                {
                    id = level.Id,
                    title = level.Title,
                    cycleId = level.Cycle_Id,
                    cycleTitle = level.Cycles.Title
                };
                niveaux.Add(niveau);
            }
            return niveaux;
        }

        private List<ClasseModels> getListClasses(IQueryable<Classrooms> classes)
        {
            List<ClasseModels> classrooms = new List<ClasseModels>();
            foreach (var c in classes)
            {
                ClasseModels classe = new ClasseModels
                {
                    id = c.Id,
                    etablissementId = c.Establishment_Id,
                    title = c.Title,
                    userId = c.User_Id,
                    yearId = c.Year_Id
                };
                classrooms.Add(classe);
            }
            return classrooms;
        }

        private List<EvaluationModels> getListEvaluations(IQueryable<Evaluations> ev)
        {
            List<EvaluationModels> evaluations = new List<EvaluationModels>();
            foreach (var e in ev)
            {
                EvaluationModels eval = new EvaluationModels
                {
                    id = e.Id,
                    periodId = e.Period_Id,
                    userId = e.User_Id,
                    classroomName = e.Classrooms.Title,
                    userName = e.Users.UserName
                };
                evaluations.Add(eval);
            }
            return evaluations;
        }

        private List<EleveModels> getListEleves(IQueryable<Pupils> pupils)
        {
            List<EleveModels> eleves = new List<EleveModels>();
            foreach (var e in pupils)
            {
                EleveModels eval = new EleveModels
                {
                    id = e.Id,
                    firstName = e.FirstName,
                    lastName = e.LastName
                };
                eleves.Add(eval);
            }
            return eleves;
        }
        //
        // GET: /Administration/

        public ActionResult Index()
        {
            return View();
        }

        //lecture de l'ensemble des cycles
        public ActionResult ReadCycles()
        {
            IList<CycleModels> models = new List<CycleModels>();
            using (CycleRepository repository = new CycleRepository())
            {
                IQueryable<Cycles> c = repository.All();

                models = repository.All().Select(x => new CycleModels
                {
                    id = x.Id,
                    title = x.Title
                }).ToList();
            }
            return View(models);
        }

        public ActionResult ReadCycle(Guid id)
        {
            CycleModels model;

            using (CycleRepository repository = new CycleRepository())
            {
                Cycles c = repository.GetCycleById(id);
                IQueryable<Levels> l = repository.GetNiveauxById(id);
                model = new CycleModels
                {
                    id = c.Id,
                    title = c.Title,
                    niveaux = getListNiveau(l)
                };
            }
            return View(model);
        }

        public ActionResult ReadNiveaux()
        {
            IList<NiveauModels> models = new List<NiveauModels>();
            using (NiveauRepository repository = new NiveauRepository())
            {

                IQueryable<Levels> c = repository.All();
                models = repository.All().Select(x => new NiveauModels
                {
                    id = x.Id,
                    title = x.Title,
                    cycleId = x.Cycle_Id,
                    cycleTitle = x.Cycles.Title
                }).ToList();
            }
            return View(models);
        }

        public ActionResult ReadNiveau(Guid id)
        {
            NiveauModels model;
            using (NiveauRepository repository = new NiveauRepository())
            {
                Levels l = repository.GetLevelById(id);
                IQueryable<Pupils> p = repository.GetElevesByLevelId(id);
                model = new NiveauModels
                {
                    id = l.Id,
                    title = l.Title,
                    cycleId = l.Cycle_Id,
                    cycleTitle = l.Cycles.Title,
                    eleves = getListEleves(p)
                };
            }
            return View(model);
        }

        public ActionResult ReadPeriodes()
        {
            IList<PeriodeModels> models = new List<PeriodeModels>();
            using (PeriodeRepository repository = new PeriodeRepository())
            {
                IQueryable<Periods> c = repository.All();

                models = repository.All().Select(x => new PeriodeModels
                {
                    id = x.Id,
                    begin = x.Begin,
                    end = x.End,
                    yearId = x.Year_Id,
                    year = x.Years.Year
                }).ToList();
            }
            return View(models);
        }

        public ActionResult ReadPeriode(Guid id)
        {
            PeriodeModels model;
            using (PeriodeRepository repository = new PeriodeRepository())
            {
                Periods p = repository.GetPeriodById(id);
                IQueryable<Evaluations> e = repository.GetEvaluationsByPeriodId(id);
                model = new PeriodeModels
                {
                    id = p.Id,
                    begin = p.Begin,
                    end = p.End,
                    yearId = p.Year_Id,
                    year = p.Years.Year,
                    evaluations = getListEvaluations(e)
                };
            }
            return View(model);
        }

        public ActionResult ReadAnnees()
        {
            IList<AnneeModels> models = new List<AnneeModels>();
            using (AnneeRepository repository = new AnneeRepository())
            {
                IQueryable<Years> c = repository.All();

                models = repository.All().Select(x => new AnneeModels
                {
                    id = x.Id,
                    year = x.Year
                }).ToList();
            }
            return View(models);
        }

        public ActionResult ReadAnnee(Guid id)
        {
            AnneeModels model;
            using (AnneeRepository repository = new AnneeRepository())
            {
                Years a = repository.GetYearById(id);
                IQueryable<Periods> l = repository.GetPeriodesById(id);
                IQueryable<Classrooms> c = repository.GetClassesByYearId(id);
                model = new AnneeModels
                {
                    id = a.Id,
                    year = a.Year,
                    periods = getListPeriode(l),
                    classes = getListClasses(c)
                };
            }
            return View(model);
        }

        private List<PeriodeModels> getListPeriode(IQueryable<Periods> periods)
        {
            List<PeriodeModels> periodes = new List<PeriodeModels>();
            foreach (var p in periods)
            {
                PeriodeModels periode = new PeriodeModels
                {
                    id = p.Id,
                    begin = p.Begin,
                    end = p.End,
                    year = p.Years.Year,
                    yearId = p.Year_Id

                };
                periodes.Add(periode);
            }
            return periodes;
        }
    }
}
