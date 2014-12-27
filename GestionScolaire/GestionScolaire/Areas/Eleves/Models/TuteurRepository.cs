using GestionScolaire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionScolaire.Areas.Eleves.Models
{
    public class TuteurRepository : IDisposable
    {
        private Entities data;

        #region Construct

        public TuteurRepository()
        {
            data = new Entities();
        }

        public TuteurRepository(Entities data)
        {
            this.data = data;
        }

        #endregion

        #region Queries

        public IQueryable<Tutors> All()
        {
            return data.Tutors;
        }

        public Tutors GetTutorById(Guid id)
        {
            return All().SingleOrDefault(Tutor => Tutor.Id == id);
        }

        public IQueryable<Tutors> GetTuteursByQuery(String query)
        {
            return All().Where(Tutor => Tutor.LastName.Contains(query) || Tutor.FirstName.Contains(query));
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
            data.Tutors.Remove(GetTutorById(id));
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