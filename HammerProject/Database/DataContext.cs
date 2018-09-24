using HammerProject.Database.Entity;
using HammerProject.Database.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace HammerProject.Database
{
    /// <summary>
    /// Database Context
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public DataContext()
            : base("DB")
        {
            Configuration.ProxyCreationEnabled = false;

        }

        // Load entities
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// On model creating set entities configurations
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Employee Config
            modelBuilder.Entity<Employee>().Property(item => item.Salary).HasPrecision(18, 2);
            modelBuilder.Entity<Employee>().HasRequired(item => item.Department).WithMany(item => item.Employees).HasForeignKey(item => item.DepartmentId).WillCascadeOnDelete(true);
        }

        /// <summary>
        /// Auto update last modified time
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            DateTime now = DateTime.Now;
            foreach (ObjectStateEntry entry in (this as IObjectContextAdapter).ObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified))
            {
                if (!entry.IsRelationship)
                {
                    IHasLastModified lastModified = entry.Entity as IHasLastModified;
                    if (lastModified != null)
                        lastModified.lastModifyDate = now;
                }
            }
            return base.SaveChanges();
        }
    }
}