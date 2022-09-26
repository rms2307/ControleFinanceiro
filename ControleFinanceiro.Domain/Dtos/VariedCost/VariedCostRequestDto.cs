namespace ControleFinanceiro.Domain.Dtos.VariedCost
{
    public class VariedCostRequestDto
    {
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DebitDay { get; set; }
    }
}
