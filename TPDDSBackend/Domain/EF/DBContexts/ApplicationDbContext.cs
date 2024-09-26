using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.Entitites;
using System;
namespace TPDDSBackend.Domain.EF.DBContexts
{
    public class ApplicationDbContext : IdentityDbContext<Collaborator>
    {
        private readonly DateTime _now = DateTime.UtcNow;

        public DbSet<Collaborator> Cards { get; set; }
        public DbSet<Food> Transactions { get; set; }
        public DbSet<Fridge> Fridge { get; set; }

        //TODO agregar las otras entidades
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = _now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModificationAt = _now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
