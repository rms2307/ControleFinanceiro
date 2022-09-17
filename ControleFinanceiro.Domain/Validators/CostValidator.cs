using ControleFinanceiro.Domain.Entities;
using FluentValidation;

namespace ControleFinanceiro.Domain.Validators
{
    public class CostValidator : AbstractValidator<Cost>
    {
        public CostValidator()
        {
            RuleFor(x => x.CategoryId)
                .NotNull();

            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .MinimumLength(45)
                .MaximumLength(3);

            RuleFor(x => x.Amount)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.DebitDay)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(DateTime.Now.Day);
        }
    }
}
