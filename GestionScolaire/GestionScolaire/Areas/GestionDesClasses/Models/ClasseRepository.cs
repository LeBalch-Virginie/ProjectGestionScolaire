using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GestionScolaire.Models;

namespace GestionScolaire.Areas.GestionDesClasses.Models
{
    public class ClasseRepository : IDisposable
    {
        private Entities data;

        #region Construct

        public ClasseRepository()
        {
            data = new Entities();
        }

        public ClasseRepository(Entities data)
        {
            this.data = data;

        }

        #endregion

        #region Queries

        public IQueryable<Classrooms> All()
        {
            return data.Classrooms;
        }

        public Classrooms GetClasseById(Guid id)
        {
            return All().SingleOrDefault(Classroom => Classroom.Id == id);
        }

        public IQueryable<Years> GetYears()
        {
            return data.Years;
        }

        public IQueryable<Users> GetUsers()
        {
            return data.Users;
        }

        public IQueryable<Establishments> GetEtablissements()
        {
            return data.Establishments;
        }

        public IQueryable<Pupils> GetPupilsById(Guid id)
        {
            return data.Pupils.Where(pupil => pupil.Classroom_Id == id);
        }

        public IQueryable<Evaluations> GetEvaluations(Guid id)
        {
            return data.Evaluations.Where(Evaluation => Evaluation.Classroom_Id == id);
        }


        public IQueryable<Classrooms> GetClassesByQuery(String query)
        {
            return All().Where(Classrooms => Classrooms.Title.Contains(query));
        }


        #endregion

        #region CRUD

        public void Add(Classrooms s)
        {
            data.Classrooms.Add(s);
        }

        public void Delete(Classrooms s)
        {
            data.Classrooms.Remove(s);
        }

        public void DeleteById(Guid id)
        {
            data.Classrooms.Remove(GetClasseById(id));
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