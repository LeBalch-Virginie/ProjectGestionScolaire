﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestionScolaire.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Academies> Academies { get; set; }
        public DbSet<Classrooms> Classrooms { get; set; }
        public DbSet<Cycles> Cycles { get; set; }
        public DbSet<Establishments> Establishments { get; set; }
        public DbSet<Evaluations> Evaluations { get; set; }
        public DbSet<Levels> Levels { get; set; }
        public DbSet<Periods> Periods { get; set; }
        public DbSet<Pupils> Pupils { get; set; }
        public DbSet<Results> Results { get; set; }
        public DbSet<Tutors> Tutors { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Years> Years { get; set; }
    }
}
