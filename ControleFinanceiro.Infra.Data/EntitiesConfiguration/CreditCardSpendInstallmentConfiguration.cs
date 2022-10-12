using ControleFinanceiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.Infra.Data.EntitiesConfiguration
{
    public class CreditCardSpendInstallmentConfiguration : IEntityTypeConfiguration<CreditCardSpendInstallment>
    {
        public void Configure(EntityTypeBuilder<CreditCardSpendInstallment> builder)
        {
            builder.ToTable("CreditCardSpendInstallment");

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

            builder.Property(x => x.InstallmentDueDate)
                .IsRequired()
                .HasColumnOrder(3);
            
            builder.Property(x => x.InstallmentAmount)
                .IsRequired()
                .HasColumnOrder(4);

            builder.Property(x => x.InstallmentNumber)
                .IsRequired()
                .HasColumnOrder(5);

            builder.Property(x => x.CreditCardSpendId)
                .IsRequired()
                .HasColumnOrder(6);
        }
    }
}