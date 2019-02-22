using FormBuilder.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace FormBuilder.DAL
{
    public class FormContext : DbContext
    {
        public FormContext() : base("FormContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<CustomForm> Forms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}