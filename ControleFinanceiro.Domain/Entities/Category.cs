using ControleFinanceiro.Domain.Entities.Base;
using ControleFinanceiro.Domain.Exceptions;
using ControleFinanceiro.Domain.Validators;

namespace ControleFinanceiro.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string? Name { get; private set; }

        public Category(int id, string? name)
        {
            Id = id;
            Name = name;
            Validate();
        }

        public Category(string? name)
        {
            Name = name;
            Validate();
        }

        public void Update(string name)
        {
            Name = name;
            Validate();
        }

        private void Validate()
        {
            CategoryValidator validations = new();
            var validationsResult = validations.Validate(this);
            if (!validationsResult.IsValid)
            {
                string errors = string.Join("; ", validationsResult.Errors.Select(x => x.ErrorMessage));
                throw new BadRequestException(errors);
            }
        }
    }
}
