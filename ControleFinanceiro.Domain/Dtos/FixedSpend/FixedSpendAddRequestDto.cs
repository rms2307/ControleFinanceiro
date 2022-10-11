namespace ControleFinanceiro.Domain.Dtos.FixedSpend
{
    public class FixedSpendAddRequestDto
    {
        public int FixedSpendCategoryId { get; set; }
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DebitDay { get; set; }

        private int frequency;
        public int Frequency
        {
            get
            {
                return frequency;
            }
            set
            {
                frequency = value <= 0 ? 1 : value;
            }
        }
    }
}
