using ControleFinanceiro.Domain.Entities.Base;
using ControleFinanceiro.Domain.Exceptions;
using ControleFinanceiro.Domain.Validators;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiro.Domain.Entities
{
    public class CreditCard : BaseEntity
    {
        public int LastFourDigits { get; private set; }
        public int InvoiceClosingDay { get; private set; }
        public int InvoiceDueDay { get; private set; }
        public decimal LimitAmount { get; private set; }

        [NotMapped]
        public decimal TotalPayable { get; private set; }
        [NotMapped]
        public decimal RemainingLimit { get; private set; }

        public IList<CreditCardSpend> CreditCardSpends { get; private set; }

        public CreditCard(int id, int lastFourDigits, int invoiceClosingDay, int invoiceDueDay, decimal limitAmount)
        {
            Id = id;
            LastFourDigits = lastFourDigits;
            InvoiceClosingDay = invoiceClosingDay;
            InvoiceDueDay = invoiceDueDay;
            LimitAmount = limitAmount;
            TotalPayable = CalculateTotalPayable();
            RemainingLimit = LimitAmount - TotalPayable;

            Validate();
        }

        public CreditCard(int lastFourDigits, int invoiceClosingDay, int invoiceDueDay, decimal limitAmount)
        {
            LastFourDigits = lastFourDigits;
            InvoiceClosingDay = invoiceClosingDay;
            InvoiceDueDay = invoiceDueDay;
            LimitAmount = limitAmount;
            TotalPayable = CalculateTotalPayable();
            RemainingLimit = LimitAmount - TotalPayable;

            Validate();
        }

        public void Update(int lastFourDigits, int invoiceClosingDay, int invoiceDueDay, decimal limitAmount)
        {
            LastFourDigits = lastFourDigits;
            InvoiceClosingDay = invoiceClosingDay;
            InvoiceDueDay = invoiceDueDay;
            LimitAmount = limitAmount;

            Validate();
        }

        public void AddCreditCardSpend(int categoryId, string? description, decimal amount, DateTime buyDay, int numberOfInstallments)
        {
            ValidateLimit(amount);
            CreditCardSpends.Add(new(categoryId, description, amount, buyDay, numberOfInstallments, this));
        }

        private decimal CalculateTotalPayable()
        {
            decimal totalPayable = 0;
            if (CreditCardSpends is null || !CreditCardSpends.Any())
                return totalPayable;

            var currentMonth = DateTime.Now.Month;
            foreach (var creditCardSpend in CreditCardSpends)
            {
                totalPayable = creditCardSpend.CreditCardSpendInstallments
                    .Where(x => x.InstallmentDueDate.Month >= currentMonth)
                    .Sum(x => x.InstallmentAmount);
            }
            return totalPayable;
        }

        private void Validate()
        {
            CreditCardValidator validations = new();
            var validationsResult = validations.Validate(this);
            if (!validationsResult.IsValid)
                throw new BadRequestException(validationsResult.Errors.Select(x => x.ErrorMessage));
        }

        private void ValidateLimit(decimal amount)
        {
            var total = TotalPayable + amount;

            if (total > LimitAmount)
                throw new ConflictException("Limite do cartão excedido.");
        }
    }
}