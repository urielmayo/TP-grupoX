using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.Entitites;
using System;
using TPDDSBackend.Domain.Entities;
namespace TPDDSBackend.Domain.EF.DBContexts
{
    public class ApplicationDbContext : IdentityDbContext<Collaborator>
    {
        private readonly DateTime _now = DateTime.UtcNow;

        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<Fridge> Fridge { get; set; }
        public DbSet<FoodState> FoodState { get; set; }

        public DbSet<Contribution> Contributions { get; set; }

        public DbSet<DeliveryReason> DeliveryReasons { get; set; }

        public DbSet<DocumentType> DocumentTypes { get; set; }

        public DbSet<FoodDelivery> FoodDeliveries { get; set; }

        public DbSet<FoodDonation> FoodDonations { get; set; }

        public DbSet<FoodXDelivery> FoodXDelivery { get; set; }

        public DbSet<FridgeOwner> FridgeOwners { get; set; }

        public DbSet<HumanPerson> HumanPerson { get; set; }

        public DbSet<LegalPerson> LegalPerson { get; set; }

        public DbSet<MoneyDonation> MoneyDonations { get; set; }

        public DbSet<Card> Cards { get; set; }


        public DbSet<PersonInVulnerableSituation> PersonInVulnerableSituations { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
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
                        entry.Entity.CreatedAt = entry.OriginalValues.GetValue<DateTime>("CreatedAt");
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);

        }

        public override int SaveChanges()
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
                        entry.Entity.CreatedAt = entry.OriginalValues.GetValue<DateTime>("CreatedAt");
                        break;
                }
            }
            return base.SaveChanges();
        }
    }
}
