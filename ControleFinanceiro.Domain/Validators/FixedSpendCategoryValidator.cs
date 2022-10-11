using ControleFinanceiro.Domain.Entities;
using FluentValidation;

namespace ControleFinanceiro.Domain.Validators
{
    public class FixedSpendCategoryValidator : AbstractValidator<FixedSpendCategory>
    {
        public FixedSpendCategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(45);
        }
    }
}
