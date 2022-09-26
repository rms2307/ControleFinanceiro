using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ControleFinanceiro.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<VariedCost> VariedCosts { get; set; }
        public DbSet<FixedCost> FixedCosts { get; set; }
        public DbSet<FixedCostCategory> FixedCostCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            UpdateSaveChanges();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override int SaveChanges()
        {
            UpdateSaveChanges();

            return base.SaveChanges();
        }

        private void UpdateSaveChanges()
        {
            var entries = ChangeTracker
                            .Entries()
                            .Where(e => e.Entity is BaseEntity &&
                                        (e.State == EntityState.Added ||
                                        e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                UpdateSaveChanges(entityEntry);
            }
        }

        private void UpdateSaveChanges(EntityEntry entityEntry)
        {
            ((BaseEntity)entityEntry.Entity).DateLog = DateTime.Now;
            ((BaseEntity)entityEntry.Entity).UserLog = "user.test"; // TODO: Add user.
        }
    }
}