using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GestionScolaire.Models;

namespace GestionScolaire.Areas.GestionDesClasses.Models
{
    public class UserRepository : IDisposable
    {
        private Entities data;

        #region Construct

        public UserRepository()
        {
            data = new Entities();
        }

        public UserRepository(Entities data)
        {
            this.data = data;

        }

        #endregion

        #region Queries

        public IQueryable<Users> All()
        {
            return data.Users;
        }

        public Users GetUserById(Guid id)
        {
            return All().SingleOrDefault(Users => Users.Id == id);
        }

        public IQueryable<Users> GetUsersByQuery(String query)
        {
            return All().Where(Users => Users.UserName.Contains(query));
        }


        #endregion

        #region CRUD

        public void Add(Users s)
        {
            data.Users.Add(s);
        }

        public void Delete(Users s)
        {
            data.Users.Remove(s);
        }

        public void DeleteById(Guid id)
        {
            data.Users.Remove(GetUserById(id));
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