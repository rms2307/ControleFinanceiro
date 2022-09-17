using ControleFinanceiro.Domain.Entities.Base;

namespace ControleFinanceiro.Domain.Entities
{
    public class CreditCard : BaseEntity
    {
        public string? Description { get; private set; }
        public int LastFourDigits { get; private set; }
        public int InvoiceClosingDay { get; private set; }
        public int InvoiceDueDay { get; private set; }
        public decimal LimitAmount { get; private set; }
    }
}