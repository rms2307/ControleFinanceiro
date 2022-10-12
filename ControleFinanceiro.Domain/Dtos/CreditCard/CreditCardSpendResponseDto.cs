namespace ControleFinanceiro.Domain.Dtos.CreditCard
{
    public class CreditCardSpendResponseDto
    {
        public int Id { get; set; }
        internal int CategoryId { get; set; }
        internal int CreditCardId { get; set; }
        internal string? Description { get; set; }
        internal decimal Amount { get; set; }
        internal DateTime BuyDay { get; set; }
        internal int NumberInstallments { get; set; }
    }
}
