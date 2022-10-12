using AutoMapper;
using ControleFinanceiro.Domain.Dtos.CreditCard;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Exceptions;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using ControleFinanceiro.Domain.Interfaces.UseCases;

namespace ControleFinanceiro.Application.UseCases
{
    public class AddSpendInCreditCardUseCase : IAddSpendInCreditCardUseCase
    {
        private readonly IMapper _mapper;
        private readonly ICreditCardRepository _creditCardRepository;

        public AddSpendInCreditCardUseCase(ICreditCardRepository creditCardRepository, IMapper mapper)
        {
            _creditCardRepository = creditCardRepository;
            _mapper = mapper;
        }

        public void AddSpendInCreditCard(int creditCardId, CreditCardSpendRequestDto request)
        {
            Validate(creditCardId, request);

            CreditCard creditCard = _creditCardRepository.GetById(creditCardId);
            Validate(creditCard);

            creditCard.AddCreditCardSpend(request.CategoryId, request.Description, request.PurchaseAmount, request.BuyDay, request.NumberInstallments);

            _creditCardRepository.Update(creditCard);
        }

        private void Validate(CreditCard creditCard)
        {
            if (creditCard is null)
                throw new NotFoundException("Cartão de crédito não encontrado.");
        }

        private void Validate(int creditCardId, CreditCardSpendRequestDto request)
        {
            if (creditCardId != request.CreditCardId)
                throw new BadRequestException("Cartão de crédito não confere.");
        }
    }
}
