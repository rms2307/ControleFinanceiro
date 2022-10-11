using ControleFinanceiro.Domain.Entities;
using FluentValidation;

namespace ControleFinanceiro.Domain.Validators
{
    public class SpendValidator : AbstractValidator<Spend>
    {
        public SpendValidator()
        {
            RuleFor(x => x.CategoryId)
                .NotNull();

            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(45);

            RuleFor(x => x.Amount)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.DebitDay)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(DateTime.Now);
        }
    }
}