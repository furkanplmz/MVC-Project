﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication3.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class finalDbEntities2 : DbContext
    {
        public finalDbEntities2()
            : base("name=finalDbEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<EmployeeT> EmployeeTs { get; set; }
        public DbSet<CustomerT> CustomerTs { get; set; }
        public DbSet<OrderT> OrderTs { get; set; }
        public DbSet<ProductT> ProductTs { get; set; }
    }
}
