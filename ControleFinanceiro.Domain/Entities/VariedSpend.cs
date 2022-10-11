using ControleFinanceiro.Domain.Exceptions;
using ControleFinanceiro.Domain.Validators;

namespace ControleFinanceiro.Domain.Entities
{
    public class VariedSpend : Spend
    {
        public VariedSpend(int id, int categoryId, string description, decimal amount, DateTime debitDay)
        {
            Id = id;
            CategoryId = categoryId;
            Description = description;
            Amount = amount;
            DebitDay = debitDay;
            Validate();
        }

        public VariedSpend(int categoryId, string description, decimal amount, DateTime debitDay)
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
            VariedSpendValidator validations = new();
            var validationsResult = validations.Validate(this);
            if (!validationsResult.IsValid)
                throw new BadRequestException(validationsResult.Errors.Select(x => x.ErrorMessage));
        }
    }
}
