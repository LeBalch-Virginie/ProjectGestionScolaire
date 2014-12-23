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