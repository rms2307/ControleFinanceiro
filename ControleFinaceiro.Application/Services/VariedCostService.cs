using AutoMapper;
using ControleFinanceiro.Domain.Dtos.VariedCost;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Exceptions;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using ControleFinanceiro.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace ControleFinanceiro.Application.Services
{
    public class VariedCostService : IVariedCostService
    {
        private readonly IMapper _mapper;
        private readonly IVariedCostRepository _variedCostRepository;

        public VariedCostService(IMapper mapper, IVariedCostRepository variedCostRepository)
        {
            _mapper = mapper;
            _variedCostRepository = variedCostRepository;
        }

        public IEnumerable<VariedCostResponseDto> GetAll()
        {
            return _mapper.Map<IEnumerable<VariedCostResponseDto>>(_variedCostRepository.GetAll());
        }

        public VariedCostResponseDto GetById(int id)
        {
            VariedCost variedCost = _variedCostRepository.GetById(id);
            ValidateNull(variedCost);

            return _mapper.Map<VariedCostResponseDto>(variedCost);
        }

        public int Add(VariedCostRequestDto dto)
        {
            VariedCost variedCost = _mapper.Map<VariedCost>(dto);
            _variedCostRepository.Add(variedCost);

            return variedCost.Id;
        }

        public void Update(int id, VariedCostRequestDto dto)
        {
            VariedCost variedCost = _variedCostRepository.GetById(id);

            ValidateNull(variedCost);

            variedCost.Update(dto.CategoryId, dto.Description, dto.Amount, dto.DebitDay);
            _variedCostRepository.Update(variedCost);
        }

        public void Delete(int id)
        {
            VariedCost variedCost = _variedCostRepository.GetById(id);
            ValidateNull(variedCost);

            _variedCostRepository.Delete(variedCost);
        }

        private static void ValidateNull(VariedCost variedCostDto)
        {
            if (variedCostDto is null)
                throw new NotFoundException("Categoria não encontrada.");
        }
    }
}
