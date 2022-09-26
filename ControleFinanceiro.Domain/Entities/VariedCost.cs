using ControleFinanceiro.Domain.Exceptions;
using ControleFinanceiro.Domain.Validators;

namespace ControleFinanceiro.Domain.Entities
{
    public class VariedCost : Cost
    {
        public VariedCost(int id, int categoryId, string description, decimal amount, DateTime debitDay)
        {
            Id = id;
            CategoryId = categoryId;
            Description = description;
            Amount = amount;
            DebitDay = debitDay;
            Validate();
        }

        public VariedCost(int categoryId, string description, decimal amount, DateTime debitDay)
        {
            CategoryId = categoryId;
            Description = description;
            Amount = amount;
            DebitDay = debitDay;
            Validate();
        }

        public void Update(int categoryId, string description, decimal amount, DateTime debitDay)
        {
            CategoryId = categoryId;
            Description = description;
            Amount = amount;
            DebitDay = debitDay;
            Validate();
        }

        private void Validate()
        {
            VariedCostValidator validations = new();
            var validationsResult = validations.Validate(this);
            if (!validationsResult.IsValid)
                throw new BadRequestException(validationsResult.Errors.Select(x => x.ErrorMessage));
        }
    }
}
