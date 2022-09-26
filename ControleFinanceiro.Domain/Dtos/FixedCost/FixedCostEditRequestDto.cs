namespace ControleFinanceiro.Domain.Dtos.FixedCost
{
    public class FixedCostEditRequestDto
    {
        public int CategoryId { get; set; }
        public int FixedCostCategoryId { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DebitDay { get; set; }
    }
}
