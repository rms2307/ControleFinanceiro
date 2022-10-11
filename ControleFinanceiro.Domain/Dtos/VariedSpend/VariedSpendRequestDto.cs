namespace ControleFinanceiro.Domain.Dtos.VariedSpend
{
    public class VariedSpendRequestDto
    {
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DebitDay { get; set; }
    }
}
