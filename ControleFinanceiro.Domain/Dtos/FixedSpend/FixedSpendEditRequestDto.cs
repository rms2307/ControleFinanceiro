namespace ControleFinanceiro.Domain.Dtos.FixedSpend
{
    public class FixedSpendEditRequestDto
    {
        public int CategoryId { get; set; }
        public int FixedSpendCategoryId { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DebitDay { get; set; }
    }
}
