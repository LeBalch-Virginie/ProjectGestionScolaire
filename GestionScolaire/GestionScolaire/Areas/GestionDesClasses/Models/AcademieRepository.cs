using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionScolaire.Models
{
    public class AcademieRepository : IDisposable
    {
        private Entities data;

        #region Construct

        public AcademieRepository()
        {
            data = new Entities();
        }

        public AcademieRepository(Entities data)
        {
            this.data = data;
        }

        #endregion

        #region Queries

        public IQueryable<Academies> All()
        {
            return data.Academies;
        }

        public Academies GetAcademieById(Guid id)
        {
            return All().SingleOrDefault(Academie => Academie.Id == id);
        }

        #endregion

        #region CRUD

        public void Add(Academies s)
        {
            data.Academies.Add(s);
        }

        public void Delete(Academies s)
        {
            data.Academies.Remove(s);
        }

        public void DeleteById(Guid id)
        {
            data.Academies.Remove(GetAcademieById(id));
        }

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