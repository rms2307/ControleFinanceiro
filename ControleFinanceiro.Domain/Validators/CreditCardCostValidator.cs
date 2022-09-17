using ControleFinanceiro.Domain.Entities;
using FluentValidation;

namespace ControleFinanceiro.Domain.Validators
{
    public class CreditCardCostValidator : AbstractValidator<CreditCardCost>
    {
        public CreditCardCostValidator()
        {
            RuleFor(x => x.CategoryId)
                .NotNull();

            RuleFor(x => x.CreditCardId)
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

            RuleFor(x => x.BuyDay)
                .GreaterThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.NumberInstallments)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(1);
        }
    }
}
