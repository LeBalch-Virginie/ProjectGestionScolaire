using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GestionScolaire.Models;

namespace GestionScolaire.Areas.Eleves.Models
{
    public class EleveRepository : IDisposable
    {
        private Entities data;

        #region Construct

        public EleveRepository()
        {
            data = new Entities();
        }

        public EleveRepository(Entities data)
        {
            this.data = data;
        }

        #endregion

        #region Queries

        public IQueryable<Tutors> All()
        {
            return data.Tutors;
        }

        public Tutors GetPupilById(Guid id)
        {
            return All().SingleOrDefault(Tutor => Tutor.Id == id);
        }
        #endregion

        #region CRUD

        public void Add(Tutors s)
        {
            data.Tutors.Add(s);
        }

        public void Delete(Tutors s)
        {
            data.Tutors.Remove(s);
        }

        public void DeleteById(Guid id)
        {
            data.Tutors.Remove(GetPupilById(id));
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