using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GestionScolaire.Models;

namespace GestionScolaire.Areas.Administration.Models
{
    public class PeriodeRepository : IDisposable
    {
                private Entities data;

        #region Construct

        public PeriodeRepository()
        {
            data = new Entities();
        }

        public PeriodeRepository(Entities data)
        {
            this.data = data;
        }

        #endregion

        #region Queries

        public IQueryable<Periods> All()
        {
            return data.Periods;
        }

        public Periods GetPeriodById(Guid id)
        {
            return All().SingleOrDefault(periode => periode.Id == id);
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