﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entidades
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DsigeProyectosEntities : DbContext
    {
        public DsigeProyectosEntities()
            : base("name=DsigeProyectosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Alm_Articulo> Alm_Articulo { get; set; }
        public virtual DbSet<Pub_Usuarios> Pub_Usuarios { get; set; }
        public virtual DbSet<tbl_Aceesos_Evento> tbl_Aceesos_Evento { get; set; }
        public virtual DbSet<tbl_Definicion_Opciones> tbl_Definicion_Opciones { get; set; }
    }
}
