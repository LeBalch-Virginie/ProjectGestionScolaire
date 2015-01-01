using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GestionScolaire.Models;

namespace GestionScolaire.Areas.Eval.Models
{
    public class EvaluationRepository : IDisposable
    {
        private Entities data;

        #region Construct

        public EvaluationRepository()
        {
            data = new Entities();
        }

        public EvaluationRepository(Entities data)
        {
            this.data = data;
        }

        #endregion

        #region Queries

        public IQueryable<Evaluations> All()
        {
            return data.Evaluations;
        }

        public Evaluations GetEvaluationById(Guid id)
        {
            return All().SingleOrDefault(Evaluation => Evaluation.Id == id);
        }

        public Guid GetClassroomId(Evaluations e)
        {
            return e.Classroom_Id;
        }

        public IQueryable<Pupils> GetPupilsByClassroom(Guid id)
        {
            return data.Pupils.Where(Pupil => Pupil.Classroom_Id == id);
        }

        #endregion

        #region CRUD

        public void Add(Evaluations s)
        {
            data.Evaluations.Add(s);
        }

        public void Delete(Evaluations s)
        {
            data.Evaluations.Remove(s);
        }

        public void DeleteById(Guid id)
        {
            data.Evaluations.Remove(GetEvaluationById(id));
        }



        public IQueryable<Classrooms> GetClasses()
        {
            return data.Classrooms;
        }

        public IQueryable<Periods> GetPeriodes()
        {
            return data.Periods;
        }

        public IQueryable<Users> GetUsers()
        {
            return data.Users;
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