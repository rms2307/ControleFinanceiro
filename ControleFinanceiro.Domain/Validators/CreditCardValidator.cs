using ControleFinanceiro.Domain.Entities;
using FluentValidation;

namespace ControleFinanceiro.Domain.Validators
{
    public class CreditCardValidator : AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(45);

            RuleFor(x => x.LastFourDigits)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.LastFourDigits.ToString())
                .MaximumLength(4);

            RuleFor(x => x.InvoiceClosingDay)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.InvoiceDueDay)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.LimitAmount)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}