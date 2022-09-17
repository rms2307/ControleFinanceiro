using ControleFinanceiro.Domain.Entities.Base;

namespace ControleFinanceiro.Domain.Entities
{
    public class CreditCardCost : BaseEntity
    {
        public int CategoryId { get; private set; }
        public Category? Category { get; private set; }
        public int CreditCardId { get; set; }
        public CreditCard? CreditCard { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime BuyDay { get; set; }
        public int NumberInstallments { get; set; }
    }
}
