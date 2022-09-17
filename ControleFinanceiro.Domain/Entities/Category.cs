using ControleFinanceiro.Domain.Entities.Base;

namespace ControleFinanceiro.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string? Name { get; private set; }
    }
}
