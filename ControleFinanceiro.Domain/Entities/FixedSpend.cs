using ControleFinanceiro.Domain.Exceptions;
using ControleFinanceiro.Domain.Validators;

namespace ControleFinanceiro.Domain.Entities
{
    public class FixedSpend : Spend
    {
        public int FixedSpendCategoryId { get; private set; }
        public FixedSpendCategory? FixedSpendCategory { get; private set; }

        public FixedSpend(int id, int categoryId, string description, decimal amount, DateTime debitDay, int fixedSpendCategoryId)
        {
            Id = id;
            CategoryId = categoryId;
            Description = description;
            Amount = amount;
            DebitDay = debitDay;
            FixedSpendCategoryId = fixedSpendCategoryId;
            Validate();
        }

        public FixedSpend(int categoryId, string description, decimal amount, DateTime debitDay, int fixedSpendCategoryId)
        {
            CategoryId = categoryId;
            Description = description;
            Amount = amount;
            DebitDay = debitDay;
            FixedSpendCategoryId = fixedSpendCategoryId;
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
            FixedSpendValidator validations = new();
            var validationsResult = validations.Validate(this);
            if (!validationsResult.IsValid)
                throw new BadRequestException(validationsResult.Errors.Select(x => x.ErrorMessage));
        }
    }
}
