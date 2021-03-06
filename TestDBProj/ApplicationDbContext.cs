using TestDBProj.Interfaces;
using TestDBProj.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace TestDBProj
{
    public class ApplicationDbContext : DbContext
    {
        // DBSets Go here
        public DbSet<BikeRackLocation> BikeRackLocations { get; set; }
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<ModelType> ModelTypes { get; set; }
        public DbSet<UserInformation> UsersInformation { get; set; } 
        public DbSet<Bike_ModelType> Bike_ModelTypes { get; set; }
        public DbSet<Bike_UserInformation> Bike_UsersInformation { get; set; }
        public DbSet<Bike_BikeRackLocation> Bike_BikeRackLocations { get; set; }

        public ApplicationDbContext(DbContextOptions dbCntextOptions) : base(dbCntextOptions) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder sets here
            builder.Entity<BikeRackLocation>().ToTable("bikeracklocation", "csc4402");
            builder.Entity<Bike>().ToTable("bike", "csc4402");
            builder.Entity<ModelType>().ToTable("modeltype", "csc4402");
            builder.Entity<UserInformation>().ToTable("userinformation", "csc4402");
            builder.Entity<Bike_ModelType>().ToTable("bike_modeltypes", "csc4402");
            builder.Entity<Bike_UserInformation>().ToTable("bike_userinformation", "csc4402");
            builder.Entity<Bike_BikeRackLocation>().ToTable("bike_bikeracklocation", "csc4402");
        }

        public override int SaveChanges()
        {
            UpdateAuditEntities();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            UpdateAuditEntities();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateAuditEntities();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateAuditEntities();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        /// <summary>
        /// Updates auditable entities based on current time and current user.
        /// </summary>
        private void UpdateAuditEntities()
        {
            if (ChangeTracker != null)
            {
                var modifiedEntries = ChangeTracker.Entries().Where(x => x.Entity is IAuditableEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
                foreach (var entry in modifiedEntries)
                {
                    var entity = (IAuditableEntity)entry.Entity;
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedDate = now;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }

                    entity.UpdatedDate = now;

                }
            }
        }

        public void DetachAllEntities()
        {
            var changedEntriesCopy = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }
    }
}
