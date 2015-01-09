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

        public IQueryable<Pupils> All()
        {
            return data.Pupils;
        }

        public Pupils GetPupilById(Guid id)
        {
            return All().SingleOrDefault(Tutor => Tutor.Id == id);
        }

        public IQueryable<Pupils> GetElevesByQuery(String query)
        {
            return All().Where(Pupil => Pupil.LastName.Contains(query) || Pupil.FirstName.Contains(query));
        }

        public IQueryable<Results> GetResultatsByPupilId(Guid id)
        {
            return data.Results.Where(res => res.Pupil_Id == id);
        }

        #endregion

        #region CRUD

        public void Add(Pupils s)
        {
            data.Pupils.Add(s);
        }

        public void Delete(Pupils s)
        {
            data.Pupils.Remove(s);
        }

        public void DeleteById(Guid id)
        {
            data.Pupils.Remove(GetPupilById(id));
        }


        public IQueryable<Tutors> GetTutors()
        {
            return data.Tutors;
        }


        public IQueryable<Classrooms> GetClasses()
        {
            return data.Classrooms;
        }

        public IQueryable<Levels> GetNiveaux()
        {
            return data.Levels;
        }

        public IQueryable<Evaluations> GetEvaluations()
        {
            return data.Evaluations;
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