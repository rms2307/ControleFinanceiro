using ControleFinanceiro.Domain.Entities.Base;

namespace ControleFinanceiro.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string? Name { get; private set; }

        public Category(int id, string? name)
        {
            Id = id;
            Name = name;
        }

        public Category(string? name)
        {
            Name = name;
        }

        public void Atualizar(string name)
        {
            Name = name;
        }
    }
}
