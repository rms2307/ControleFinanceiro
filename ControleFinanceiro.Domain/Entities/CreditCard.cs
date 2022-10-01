using ControleFinanceiro.Domain.Entities.Base;
using ControleFinanceiro.Domain.Exceptions;
using ControleFinanceiro.Domain.Validators;

namespace ControleFinanceiro.Domain.Entities
{
    public class CreditCard : BaseEntity
    {
        public string Description { get; private set; }
        public int LastFourDigits { get; private set; }
        public int InvoiceClosingDay { get; private set; }
        public int InvoiceDueDay { get; private set; }
        public decimal LimitAmount { get; private set; }

        public CreditCard(int id, string description, int lastFourDigits, 
            int invoiceClosingDay, int invoiceDueDay, decimal limitAmount)
        {
            Id = id;
            Description = description;
            LastFourDigits = lastFourDigits;
            InvoiceClosingDay = invoiceClosingDay;
            InvoiceDueDay = invoiceDueDay;
            LimitAmount = limitAmount;
            Validate();
        }

        public CreditCard(string description, int lastFourDigits,
            int invoiceClosingDay, int invoiceDueDay, decimal limitAmount)
        {
            Description = description;
            LastFourDigits = lastFourDigits;
            InvoiceClosingDay = invoiceClosingDay;
            InvoiceDueDay = invoiceDueDay;
            LimitAmount = limitAmount;
            Validate();
        }

        public void Update(string description, int lastFourDigits,
            int invoiceClosingDay, int invoiceDueDay, decimal limitAmount)
        {
            Description = description;
            LastFourDigits = lastFourDigits;
            InvoiceClosingDay = invoiceClosingDay;
            InvoiceDueDay = invoiceDueDay;
            LimitAmount = limitAmount;
            Validate();
        }

        private void Validate()
        {
            CreditCardValidator validations = new();
            var validationsResult = validations.Validate(this);
            if (!validationsResult.IsValid)
                throw new BadRequestException(validationsResult.Errors.Select(x => x.ErrorMessage));
        }
    }
}