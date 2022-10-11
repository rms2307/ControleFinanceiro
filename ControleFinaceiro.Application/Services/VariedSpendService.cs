using AutoMapper;
using ControleFinanceiro.Domain.Dtos.VariedSpend;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Exceptions;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using ControleFinanceiro.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace ControleFinanceiro.Application.Services
{
    public class VariedSpendService : IVariedSpendService
    {
        private readonly IMapper _mapper;
        private readonly IVariedSpendRepository _variedSpendRepository;

        public VariedSpendService(IMapper mapper, IVariedSpendRepository variedSpendRepository)
        {
            _mapper = mapper;
            _variedSpendRepository = variedSpendRepository;
        }

        public IEnumerable<VariedSpendResponseDto> GetAll()
        {
            return _mapper.Map<IEnumerable<VariedSpendResponseDto>>(_variedSpendRepository.GetAll());
        }

        public VariedSpendResponseDto GetById(int id)
        {
            VariedSpend variedSpend = _variedSpendRepository.GetById(id);
            ValidateNull(variedSpend);

            return _mapper.Map<VariedSpendResponseDto>(variedSpend);
        }

        public int Add(VariedSpendRequestDto dto)
        {
            VariedSpend variedSpend = _mapper.Map<VariedSpend>(dto);
            _variedSpendRepository.Add(variedSpend);

            return variedSpend.Id;
        }

        public void Update(int id, VariedSpendRequestDto dto)
        {
            VariedSpend variedSpend = _variedSpendRepository.GetById(id);

            ValidateNull(variedSpend);

            variedSpend.Update(dto.CategoryId, dto.Description, dto.Amount, dto.DebitDay);
            _variedSpendRepository.Update(variedSpend);
        }

        public void Delete(int id)
        {
            VariedSpend variedSpend = _variedSpendRepository.GetById(id);
            ValidateNull(variedSpend);

            _variedSpendRepository.Delete(variedSpend);
        }

        private static void ValidateNull(VariedSpend variedSpendDto)
        {
            if (variedSpendDto is null)
                throw new NotFoundException("Categoria não encontrada.");
        }
    }
}
