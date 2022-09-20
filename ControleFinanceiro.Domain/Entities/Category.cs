using ControleFinanceiro.Domain.Entities.Base;
using ControleFinanceiro.Domain.Validators;

namespace ControleFinanceiro.Domain.Entities
{
    public class Category : BaseEntity
    {
        private readonly CategoryValidator validation = new();

        public string? Name { get; private set; }

        public Category(int id, string? name)
        {
            Id = id;
            Name = name;

            validation.Validate(this);
        }

        public Category(string? name)
        {
            Name = name;
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
