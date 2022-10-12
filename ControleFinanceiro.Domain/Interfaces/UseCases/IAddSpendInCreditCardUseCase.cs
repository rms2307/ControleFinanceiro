using ControleFinanceiro.Domain.Dtos.CreditCard;

namespace ControleFinanceiro.Domain.Interfaces.UseCases
{
    public interface IAddSpendInCreditCardUseCase
    {
        void AddSpendInCreditCard(int creditCardId, CreditCardSpendRequestDto request);
    }
}
