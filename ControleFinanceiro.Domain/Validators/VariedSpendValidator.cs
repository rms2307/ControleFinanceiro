using ControleFinanceiro.Domain.Entities;
using FluentValidation;

namespace ControleFinanceiro.Domain.Validators
{
    public class VariedSpendValidator : AbstractValidator<VariedSpend>
    {
        public VariedSpendValidator()
        {
            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(45);

            RuleFor(x => x.Amount)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.DebitDay)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(DateTime.Now);
        }
    }
}
