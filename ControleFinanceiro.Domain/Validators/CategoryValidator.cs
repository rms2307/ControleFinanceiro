using ControleFinanceiro.Domain.Entities;
using FluentValidation;

namespace ControleFinanceiro.Domain.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(45);
        }
    }
}
