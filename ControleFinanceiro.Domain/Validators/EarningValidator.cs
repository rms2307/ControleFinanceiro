using ControleFinanceiro.Domain.Entities;
using FluentValidation;

namespace ControleFinanceiro.Domain.Validators
{
    public class EarningValidator : AbstractValidator<Earning>
    {
        public EarningValidator()
        {
            RuleFor(x => x.CategoryId)
                .NotNull();

            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(45);

            RuleFor(x => x.DateOfEarning)
               .GreaterThanOrEqualTo(DateTime.Now);
        }
    }
}