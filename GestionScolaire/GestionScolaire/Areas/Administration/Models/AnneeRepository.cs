using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GestionScolaire.Models;

namespace GestionScolaire.Areas.Administration.Models
{
    public class AnneeRepository : IDisposable
    {
        private Entities data;

        #region Construct

        public AnneeRepository()
        {
            data = new Entities();
        }

        public AnneeRepository(Entities data)
        {
            this.data = data;
        }

        #endregion

        #region Queries

        public IQueryable<Years> All()
        {
            return data.Years;
        }

        public Years GetYearById(Guid id)
        {
            return All().SingleOrDefault(year => year.Id == id);
        }

        public IQueryable<Periods> GetPeriodesById(Guid id)
        {
            return data.Periods.Where(periode => periode.Year_Id == id);
        }

        public IQueryable<Classrooms> GetClassesByYearId(Guid id)
        {
            return data.Classrooms.Where(classe => classe.Year_Id == id);
        }

        #endregion

        #region CRUD



        #endregion

        public void Save()
        {
            data.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}