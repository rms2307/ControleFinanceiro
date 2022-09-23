namespace ControleFinanceiro.Domain.Dtos.VariedCost
{
    public class VariedCostResponseDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public int DebitDay { get; set; }
    }
}
