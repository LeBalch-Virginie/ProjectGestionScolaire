//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Establishments
    {
        public Establishments()
        {
            this.Classrooms = new HashSet<Classrooms>();
        }
    
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string Town { get; set; }
        public System.Guid User_Id { get; set; }
        public System.Guid Academie_Id { get; set; }
    
        public virtual Academies Academies { get; set; }
        public virtual ICollection<Classrooms> Classrooms { get; set; }
        public virtual Users Users { get; set; }
    }
}
