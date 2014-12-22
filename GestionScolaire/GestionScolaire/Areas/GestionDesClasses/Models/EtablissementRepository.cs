using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionScolaire.Models
{
    public class EtablissementRepository : IDisposable
    {
        private Entities data;

        #region Construct

        public EtablissementRepository()
        {
            data = new Entities();
        }

        public EtablissementRepository(Entities data)
        {
            this.data = data;

        }

        #endregion

        #region Queries

        public IQueryable<Establishments> All()
        {
            return data.Establishments;
        }

        public Establishments GetEtablissementById(Guid id)
        {
            return All().SingleOrDefault(Establishment => Establishment.Id == id);
        }



        #endregion

        #region CRUD

        public void Add(Establishments s)
        {
            data.Establishments.Add(s);
        }

        public void Delete(Establishments s)
        {
            data.Establishments.Remove(s);
        }

        public void DeleteById(Guid id)
        {
            data.Establishments.Remove(GetEtablissementById(id));
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