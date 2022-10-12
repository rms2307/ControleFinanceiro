namespace ControleFinanceiro.Domain.Dtos.CreditCard
{
    public class CreditCardRequestDto
    {
        public int LastFourDigits { get; set; }
        public int InvoiceClosingDay { get; set; }
        public int InvoiceDueDay { get; set; }
        public decimal LimitAmount { get; set; }
    }
}
