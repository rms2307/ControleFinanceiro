using ControleFinanceiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

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

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnOrder(3);
        }
    }
}