using ControleFinanceiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.Infra.Data.EntitiesConfiguration
{
    public class VariedSpendConfiguration : IEntityTypeConfiguration<VariedSpend>
    {
        public void Configure(EntityTypeBuilder<VariedSpend> builder)
        {
            builder.ToTable("VariedSpend");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnOrder(0);

            builder.Property(x => x.UserLog)
                .IsRequired()
                .HasMaxLength(45)
                .HasColumnOrder(1);

            builder.Property(x => x.DateLog)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnOrder(2);

            builder.Property(x => x.CategoryId)
                .IsRequired()
                .HasColumnOrder(3);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(45)
                .HasColumnOrder(4);

            builder.Property(x => x.Amount)
                .IsRequired()
                .HasColumnOrder(5);

            builder.Property(x => x.DebitDay)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnOrder(6);
        }
    }
}