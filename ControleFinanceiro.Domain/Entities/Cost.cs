using ControleFinanceiro.Domain.Entities.Base;

namespace ControleFinanceiro.Domain.Entities
{
    public class Cost : BaseEntity
    {
        public int CategoryId { get; protected set; }
        public Category? Category { get; protected set; }
        public string? Description { get; protected set; }
        public decimal Amount { get; protected set; }

        private DateTime debitDay;
        public DateTime DebitDay
        {
            get
            {
                return debitDay;
            }
            protected set
            {
                debitDay = new DateTime(value.Year, value.Month, value.Day);
            }
        }
    }
}