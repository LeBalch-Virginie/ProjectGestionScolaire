﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GestionScolaire.Models;

namespace GestionScolaire.Areas.Administration.Models
{
    public class CycleRepository : IDisposable
    {
        private Entities data;

        #region Construct

        public CycleRepository()
        {
            data = new Entities();
        }

        public CycleRepository(Entities data)
        {
            this.data = data;
        }

        #endregion

        #region Queries

        public IQueryable<Cycles> All()
        {
            return data.Cycles;
        }

        public Cycles GetCycleById(Guid id)
        {
            return All().SingleOrDefault(cycle => cycle.Id == id);
        }

        public IQueryable<Levels> GetNiveauxById(Guid id)
        {
            return data.Levels.Where(level => level.Cycle_Id == id);
        }

        #endregion

        #region CRUD
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