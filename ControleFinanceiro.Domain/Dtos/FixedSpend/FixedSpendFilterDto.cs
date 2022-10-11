namespace ControleFinanceiro.Domain.Dtos.FixedSpend
{
    public class FixedSpendFilterDto
    {
        public bool Previous { get; set; } = false;
        public bool Current { get; set; } = false;
        public bool Upcoming { get; set; } = false;
        public bool All { get; set; } = false;
    }
}
