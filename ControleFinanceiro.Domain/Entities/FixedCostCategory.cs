using ControleFinanceiro.Domain.Entities.Base;
using ControleFinanceiro.Domain.Exceptions;
using ControleFinanceiro.Domain.Validators;

namespace ControleFinanceiro.Domain.Entities
{
    public class FixedCostCategory : BaseEntity
    {
        public string Name { get; set; }

        public FixedCostCategory(int id, string name)
        {
            Id = id;
            Name = name;
            Validate();
        }

        public FixedCostCategory(string name)
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
            FixedCostCategoryValidator validations = new();
            var validationsResult = validations.Validate(this);
            if (!validationsResult.IsValid)
                throw new BadRequestException(validationsResult.Errors.Select(x => x.ErrorMessage));
        }
    }
}
