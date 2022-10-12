using ControleFinanceiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.Infra.Data.EntitiesConfiguration
{
    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.ToTable("CreditCard");

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

            builder.Property(x => x.LastFourDigits)
                .IsRequired()
                .HasColumnOrder(3);
            
            builder.Property(x => x.InvoiceClosingDay)
                .IsRequired()
                .HasColumnOrder(4);

            builder.Property(x => x.InvoiceDueDay)
                .IsRequired()
                .HasColumnOrder(5);

            builder.Property(x => x.LimitAmount)
                .IsRequired()
                .HasColumnOrder(6);
        }
    }
}