using GestionScolaire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionScolaire.Areas.Eval.Models
{
    public class ResultatRepository : IDisposable
    {
        private Entities data;

        #region Construct

        public ResultatRepository()
        {
            data = new Entities();
        }

        public ResultatRepository(Entities data)
        {
            this.data = data;
        }

        #endregion

        #region Queries

        public IQueryable<Results> All()
        {
            return data.Results;
        }

        public Results GetResultById(Guid id)
        {
            return All().SingleOrDefault(Result => Result.Id == id);
        }
        #endregion

        #region CRUD

        public void Add(Results s)
        {
            data.Results.Add(s);
        }

        public void Delete(Results s)
        {
            data.Results.Remove(s);
        }

        public void DeleteById(Guid id)
        {
            data.Results.Remove(GetResultById(id));
        }

        public IQueryable<Pupils> GetEleves()
        {
            return data.Pupils;
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