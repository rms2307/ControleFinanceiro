using ControleFinanceiro.Domain.Entities;
using FluentValidation;

namespace ControleFinanceiro.Domain.Validators
{
    public class CreditCardSpendValidator : AbstractValidator<CreditCardSpend>
    {
        public CreditCardSpendValidator()
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

            RuleFor(x => x.NumberOfInstallments)
                .NotNull()
                .NotEmpty()                
                .GreaterThan(0);

            RuleFor(x => x.BuyDay)
                .NotNull()
                .NotEmpty();
        }
    }
}
