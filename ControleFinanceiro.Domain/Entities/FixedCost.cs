using ControleFinanceiro.Domain.Exceptions;
using ControleFinanceiro.Domain.Validators;

namespace ControleFinanceiro.Domain.Entities
{
    public class FixedCost : Cost
    {
        public int FixedCostCategoryId { get; private set; }
        public FixedCostCategory? FixedCostCategory { get; private set; }

        public FixedCost(int id, int categoryId, string description, decimal amount, DateTime debitDay, int fixedCostCategoryId)
        {
            Id = id;
            CategoryId = categoryId;
            Description = description;
            Amount = amount;
            DebitDay = debitDay;
            FixedCostCategoryId = fixedCostCategoryId;
            Validate();
        }

        public FixedCost(int categoryId, string description, decimal amount, DateTime debitDay, int fixedCostCategoryId)
        {
            CategoryId = categoryId;
            Description = description;
            Amount = amount;
            DebitDay = debitDay;
            FixedCostCategoryId = fixedCostCategoryId;
            Validate();
        }

        public void Update(int categoryId, string description, decimal amount, DateTime debitDay)
        {
            CategoryId = categoryId;
            Description = description;
            Amount = amount;
            DebitDay = new DateTime(DebitDay.Year, DebitDay.Month, debitDay.Day);
            Validate();
        }

        private void Validate()
        {
            FixedCostValidator validations = new();
            var validationsResult = validations.Validate(this);
            if (!validationsResult.IsValid)
                throw new BadRequestException(validationsResult.Errors.Select(x => x.ErrorMessage));
        }
    }
}
