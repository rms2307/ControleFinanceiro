using ControleFinanceiro.Domain.Entities.Base;
using ControleFinanceiro.Domain.Exceptions;
using ControleFinanceiro.Domain.Validators;

namespace ControleFinanceiro.Domain.Entities
{
    public class CreditCardSpendInstallment : BaseEntity
    {
        public DateTime InstallmentDueDate { get; private set; }
        public decimal InstallmentAmount { get; set; }
        public int InstallmentNumber { get; set; }
        public CreditCardSpend? CreditCardSpend { get; set; }
        public int CreditCardSpendId { get; set; }

        public CreditCardSpendInstallment(int id, DateTime installmentDueDate, decimal installmentAmount,
            int installmentNumber, int creditCardSpendId)
        {
            Id = id;
            InstallmentDueDate = installmentDueDate;
            InstallmentAmount = installmentAmount;
            InstallmentNumber = installmentNumber;
            CreditCardSpendId = creditCardSpendId;

            Validate();
        }

        public CreditCardSpendInstallment(DateTime installmentDueDate, decimal installmentAmount,
            int installmentNumber, int creditCardSpendId)
        {
            InstallmentDueDate = installmentDueDate;
            InstallmentAmount = installmentAmount;
            InstallmentNumber = installmentNumber;
            CreditCardSpendId = creditCardSpendId;

            Validate();
        }

        private void Validate()
        {
            CreditCardSpendInstallmentValidator validations = new();
            var validationsResult = validations.Validate(this);
            if (!validationsResult.IsValid)
                throw new BadRequestException(validationsResult.Errors.Select(x => x.ErrorMessage));
        }
    }
}
