﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExcelManageITService
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ManageITDemoEntities : DbContext
    {


        public ManageITDemoEntities(String db)
            : base(db)
        {
        }


        public ManageITDemoEntities()
            : base("name=ManageITDemoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AccessControl> AccessControls { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Lead> Leads { get; set; }
        public virtual DbSet<Opportunity> Opportunities { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UIElement> UIElements { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<campaign> campaigns { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}