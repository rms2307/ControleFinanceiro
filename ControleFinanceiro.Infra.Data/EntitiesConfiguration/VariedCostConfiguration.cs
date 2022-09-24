using ControleFinanceiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.Infra.Data.EntitiesConfiguration
{
    public class VariedCostConfiguration : IEntityTypeConfiguration<VariedCost>
    {
        public void Configure(EntityTypeBuilder<VariedCost> builder)
        {
            builder.ToTable("VariedCost");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.CategoryId)
                .IsRequired();

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(45);

            builder.Property(x => x.Amount)
                .IsRequired();

            builder.Property(x => x.DebitDay)
                .IsRequired();

            builder.Property(x => x.UserLog)
                .IsRequired()
                .HasMaxLength(45);

            builder.Property(x => x.DateLog)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP"); 
        }
    }
}