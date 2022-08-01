using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data {

    public class ApplicationDbContext : DbContext, IApplicationDbContext {
        public DbSet<ChargeMachineEntity> ChargeMachines { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken()) {
            var addedEntities = ChangeTracker.Entries()
                .Where(e => e.Entity is TrackableEntity && (e.State == EntityState.Added));
            foreach (var entity in addedEntities) {
                ((TrackableEntity)entity.Entity).CreatedDate = DateTime.UtcNow;
            }

            var modifiedEntities = ChangeTracker.Entries()
                .Where(e => e.Entity is TrackableEntity && (e.State == EntityState.Modified));
            foreach (var entity in modifiedEntities) {
                ((TrackableEntity)entity.Entity).UpdatedDate = DateTime.UtcNow;
            }

            var deletedEntities = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Deleted));
            foreach (var entityEntry in deletedEntities) {
                entityEntry.State = EntityState.Modified;
                ((BaseEntity)entityEntry.Entity).IsDeleted = true;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }

}