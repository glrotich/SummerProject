﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Final_ProjectAugust1
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UserDatabaseEntities2 : DbContext
    {
        public UserDatabaseEntities2()
            : base("name=UserDatabaseEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdvisorTB> AdvisorTBs { get; set; }
        public virtual DbSet<AppointmentTB> AppointmentTBs { get; set; }
        public virtual DbSet<MessageTB> MessageTBs { get; set; }
        public virtual DbSet<StudentTB> StudentTBs { get; set; }
        public virtual DbSet<UserTB> UserTBs { get; set; }
    }
}
