namespace ControleFinanceiro.Domain.Dtos.CreditCard
{
    public class CreditCardSpendRequestDto
    {
        public int CategoryId { get; set; }
        public int CreditCardId { get; set; }
        public string? Description { get; set; }
        public decimal PurchaseAmount { get; set; }
        public DateTime BuyDay { get; set; }

        private int numberInstallments;
        public int NumberInstallments
        {
            get
            {
                return numberInstallments;
            }
            set
            {
                numberInstallments = value <= 0 ? 1 : value;
            }
        }
    }
}
