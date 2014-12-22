using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionScolaire.Models;

namespace GestionScolaire.Areas.Administration.Controllers
{
    public class AdministrationController : Controller
    {
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
                model = new NiveauModels
                {
                    id = l.Id,
                    title = l.Title,
                    cycleId = l.Cycle_Id,
                    cycleTitle = l.Cycles.Title
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
                model = new PeriodeModels
                {
                    id = p.Id,
                    begin = p.Begin,
                    end = p.End,
                    yearId = p.Year_Id,
                    year = p.Years.Year
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
                model = new AnneeModels
                {
                    id = a.Id,
                    year = a.Year
                };
            }
            return View(model);
        }

    }
}
