﻿namespace MineralDotNet.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using MineralDotNet.Contracts;
    using MineralDotNet.Contracts.CodeFirstConventions;
    using MineralDotNet.Data.Migrations;
    using MineralDotNet.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MineralDotNetDbContext : IdentityDbContext<User>, IMineralDotNetDbContext
    {
        public MineralDotNetDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public MineralDotNetDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MineralDotNetDbContext, Configuration>());
        }

        public virtual IDbSet<Mineral> Minerals { get; set; }

        public virtual IDbSet<Color> Colors { get; set; }

        public virtual IDbSet<SpecificClass> SpecificClasses { get; set; }

        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            this.ApplyDeletableEntityRules();
            return base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public static MineralDotNetDbContext Create()
        {
            return new MineralDotNetDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new IsUnicodeAttributeConvention());

            base.OnModelCreating(modelBuilder); // Without this call EntityFramework won't be able to configure the identity model
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        private void ApplyDeletableEntityRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (
                var entry in
                    this.ChangeTracker.Entries()
                        .Where(e => e.Entity is IDeletableEntity && (e.State == EntityState.Deleted)))
            {
                var entity = (IDeletableEntity)entry.Entity;

                entity.DeletedOn = DateTime.Now;
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }
    }
}
