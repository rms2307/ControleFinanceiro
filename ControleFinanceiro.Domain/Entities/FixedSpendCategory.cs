using ControleFinanceiro.Domain.Entities.Base;
using ControleFinanceiro.Domain.Exceptions;
using ControleFinanceiro.Domain.Validators;

namespace ControleFinanceiro.Domain.Entities
{
    public class FixedSpendCategory : BaseEntity
    {
        public string Name { get; set; }

        public FixedSpendCategory(int id, string name)
        {
            Id = id;
            Name = name;
            Validate();
        }

        public FixedSpendCategory(string name)
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
            FixedSpendCategoryValidator validations = new();
            var validationsResult = validations.Validate(this);
            if (!validationsResult.IsValid)
                throw new BadRequestException(validationsResult.Errors.Select(x => x.ErrorMessage));
        }
    }
}
