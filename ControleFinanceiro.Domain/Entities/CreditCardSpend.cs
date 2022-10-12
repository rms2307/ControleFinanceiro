using ControleFinanceiro.Domain.Entities.Base;
using ControleFinanceiro.Domain.Exceptions;
using ControleFinanceiro.Domain.Validators;

namespace ControleFinanceiro.Domain.Entities
{
    public class CreditCardSpend : BaseEntity
    {
        public int CategoryId { get; private set; }
        public Category? Category { get; private set; }
        public int CreditCardId { get; private set; }
        public CreditCard? CreditCard { get; private set; }
        public string? Description { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime BuyDay { get; private set; }
        public int NumberOfInstallments { get; private set; }

        public IList<CreditCardSpendInstallment> CreditCardSpendInstallments { get; set; } = new List<CreditCardSpendInstallment>();

        public CreditCardSpend(int id, int categoryId, int creditCardId, string? description,
            decimal amount, DateTime buyDay, int numberOfInstallments)
        {
            Id = id;
            CategoryId = categoryId;
            CreditCardId = creditCardId;
            Description = description;
            Amount = amount;
            BuyDay = buyDay.Date;
            NumberOfInstallments = numberOfInstallments;

            Validate();
        }

        public CreditCardSpend(int categoryId, string? description, decimal amount, DateTime buyDay,
            int numberOfInstallments, CreditCard creditCard)
        {
            CategoryId = categoryId;
            CreditCardId = creditCard.Id;
            Description = description;
            Amount = amount;
            BuyDay = buyDay.Date;
            NumberOfInstallments = numberOfInstallments;

            Validate();

            GenerateInstallments(creditCard);
        }

        public void Update(int categoryId, int creditCardId, string? description,
            decimal amount, DateTime buyDay, int numberOfInstallments)
        {
            CategoryId = categoryId;
            CreditCardId = creditCardId;
            Description = description;
            Amount = amount;
            BuyDay = buyDay.Date;
            NumberOfInstallments = numberOfInstallments;

            Validate();
        }

        private void GenerateInstallments(CreditCard creditCard)
        {
            decimal installmentAmount = Amount / NumberOfInstallments;
            int incrementedMonth;

            if (VerifyIfInvoiceClosed(creditCard)) incrementedMonth = 1;
            else incrementedMonth = 0;

            for (int i = 0; i < NumberOfInstallments; i++)
            {
                int installmentNumber = i + 1;
                DateTime installmentDueDate = new(BuyDay.Year, BuyDay.Month, creditCard.InvoiceDueDay);
                installmentDueDate = installmentDueDate.AddMonths(incrementedMonth);
                CreditCardSpendInstallment installment = new(installmentDueDate, installmentAmount, installmentNumber, Id);

                CreditCardSpendInstallments.Add(installment);
                incrementedMonth++;
            }
        }

        private bool VerifyIfInvoiceClosed(CreditCard creditCard)
        {
            return BuyDay.Day > creditCard.InvoiceClosingDay;
        }

        private void Validate()
        {
            CreditCardSpendValidator validations = new();
            var validationsResult = validations.Validate(this);
            if (!validationsResult.IsValid)
                throw new BadRequestException(validationsResult.Errors.Select(x => x.ErrorMessage));
        }
    }
}
