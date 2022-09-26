namespace ControleFinanceiro.Domain.Dtos.FixedCost
{
    public class FixedCostResponseDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DebitDay { get; set; }
    }
}
