﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Authorizathion.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RestoDb_ZadohinEntities : DbContext
    {
        public RestoDb_ZadohinEntities()
            : base("name=RestoDb_ZadohinEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Category> Category { get; set; }
        public DbSet<Cheque> Cheque { get; set; }
        public DbSet<ChequePosition> ChequePosition { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Table> Table { get; set; }
        public DbSet<Waiter> Waiter { get; set; }
    }
}
