using ControleFinanceiro.Domain.Entities.Base;

namespace ControleFinanceiro.Domain.Entities
{
    public class Earning : BaseEntity
    {
        public int CategoryId { get; private set; }
        public Category? Category { get; private set; }
        public string? Description { get; set; }
        public DateTime DateOfEarning { get; set; }
    }
}
