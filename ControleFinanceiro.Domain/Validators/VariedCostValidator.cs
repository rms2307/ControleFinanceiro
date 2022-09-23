using ControleFinanceiro.Domain.Entities;
using FluentValidation;

namespace ControleFinanceiro.Domain.Validators
{
    public class VariedCostValidator : AbstractValidator<VariedCost>
    {
        public VariedCostValidator()
        {
            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .NotNull()
                .LessThanOrEqualTo(0);

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(45);

            RuleFor(x => x.Amount)
                .NotEmpty()
                .NotNull()
                .LessThanOrEqualTo(0);

            RuleFor(x => x.DebitDay)
                .NotEmpty()
                .NotNull()
                .LessThanOrEqualTo(0);
        }
    }
}
