using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ControleFinanceiro.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateSaveChanges();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateSaveChanges();
            return await base.SaveChangesAsync(cancellationToken);
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