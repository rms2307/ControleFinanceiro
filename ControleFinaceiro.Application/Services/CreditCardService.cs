using AutoMapper;
using ControleFinanceiro.Domain.Dtos.CreditCard;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Exceptions;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using ControleFinanceiro.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace ControleFinanceiro.Application.Services
{
    public class CreditCardService : ICreditCardService
    {
        private readonly IMapper _mapper;
        private readonly ICreditCardRepository _creditCardRepository;

        public CreditCardService(ICreditCardRepository creditCardRepository, IMapper mapper)
        {
            _creditCardRepository = creditCardRepository;
            _mapper = mapper;
        }

        public IEnumerable<CreditCardResponseDto> GetAll()
        {
            return _mapper.Map<IEnumerable<CreditCardResponseDto>>(_creditCardRepository.GetAll());
        }

        public CreditCardResponseDto GetById(int id)
        {
            CreditCard creditCard = _creditCardRepository.GetById(id);
            ValidateNull(creditCard);

            return _mapper.Map<CreditCardResponseDto>(creditCard);
        }

        public int Add(CreditCardRequestDto dto)
        {
            CreditCard creditCard = _mapper.Map<CreditCard>(dto);
            _creditCardRepository.Add(creditCard);

            return creditCard.Id;
        }

        public void Update(int id, CreditCardRequestDto dto)
        {
            CreditCard creditCard = _creditCardRepository.GetById(id);
            ValidateNull(creditCard);

            creditCard.Update(dto.LastFourDigits, dto.InvoiceClosingDay, 
                dto.InvoiceDueDay, dto.LimitAmount);
            _creditCardRepository.Update(creditCard);
        }

        public void Delete(int id)
        {
            CreditCard creditCard = _creditCardRepository.GetById(id);
            ValidateNull(creditCard);

            _creditCardRepository.Delete(creditCard);
        }

        private static void ValidateNull(CreditCard creditCardDto)
        {
            if (creditCardDto is null)
                throw new NotFoundException("Cartão não encontrado.");
        }
    }
}
