using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GestionScolaire.Models;

namespace GestionScolaire.Areas.Administration.Models
{
    public class NiveauRepository : IDisposable
    {
                private Entities data;

        #region Construct

        public NiveauRepository()
        {
            data = new Entities();
        }

        public NiveauRepository(Entities data)
        {
            this.data = data;
        }

        #endregion

        #region Queries

        public IQueryable<Levels> All()
        {
            return data.Levels;
        }

        public Levels GetLevelById(Guid id)
        {
            return All().SingleOrDefault(level => level.Id == id);
        }

        public IQueryable<Pupils> GetElevesByLevelId(Guid id)
        {
            return data.Pupils.Where(pupil => pupil.Level_Id == id);
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