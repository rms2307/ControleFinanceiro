using ControleFinanceiro.Domain.Entities;
using FluentValidation;

namespace ControleFinanceiro.Domain.Validators
{
    public class CreditCardSpendInstallmentValidator : AbstractValidator<CreditCardSpendInstallment>
    {
        public CreditCardSpendInstallmentValidator()
        {
            RuleFor(x => x.InstallmentDueDate)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.InstallmentAmount)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.InstallmentNumber)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
