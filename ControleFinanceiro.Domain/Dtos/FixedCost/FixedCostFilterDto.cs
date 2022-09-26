namespace ControleFinanceiro.Domain.Dtos.FixedCost
{
    public class FixedCostFilterDto
    {
        public bool Previous { get; set; } = false;
        public bool Current { get; set; } = false;
        public bool Upcoming { get; set; } = false;
        public bool All { get; set; } = false;
    }
}
