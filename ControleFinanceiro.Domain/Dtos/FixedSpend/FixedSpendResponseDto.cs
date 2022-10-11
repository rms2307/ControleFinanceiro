namespace ControleFinanceiro.Domain.Dtos.FixedSpend
{
    public class FixedSpendResponseDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DebitDay { get; set; }
    }
}
