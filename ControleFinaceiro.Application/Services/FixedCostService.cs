using AutoMapper;
using ControleFinanceiro.Domain.Dtos.FixedCost;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Exceptions;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using ControleFinanceiro.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace ControleFinanceiro.Application.Services
{
    public class FixedCostService : IFixedCostService
    {
        private readonly IMapper _mapper;
        private readonly IFixedCostRepository _fixedCostRepository;
        private readonly IFixedCostCategoryService _fixedCostCategoryService;

        public FixedCostService(IMapper mapper, IFixedCostRepository fixedCostRepository,
            IFixedCostCategoryService fixedCostCategoryService)
        {
            _mapper = mapper;
            _fixedCostRepository = fixedCostRepository;
            _fixedCostCategoryService = fixedCostCategoryService;
        }

        public IEnumerable<FixedCostResponseDto> GetAll()
            => _mapper.Map<IEnumerable<FixedCostResponseDto>>(_fixedCostRepository.GetAll());

        public FixedCostResponseDto GetById(int id)
        {
            FixedCost fixedCost = _fixedCostRepository.GetById(id);
            ValidateNull(fixedCost);

            return _mapper.Map<FixedCostResponseDto>(fixedCost);
        }

        public void Add(FixedCostAddRequestDto dto)
        {
            List<FixedCost> fixedCosts = new();

            dto.FixedCostCategoryId = _fixedCostCategoryService.Add(dto.Description);

            FixedCost fixedCost = _mapper.Map<FixedCost>(dto);
            fixedCosts.Add(fixedCost);

            if (dto.Frequency > 1)
                GenerateCostsForNextMonths(dto, fixedCosts);

            _fixedCostRepository.AddRange(fixedCosts);
        }

        public void Update(int id, FixedCostEditRequestDto dto, FixedCostFilterDto filter)
        {
            ValidateFilter(filter);

            if (filter.Current)
            {
                UpdateCurrent(id, dto);
                return;
            }

            if (filter.All)
            {
                UpdateAll(dto);
                return;
            }

            if (filter.Previous)
            {
                UpdatePrevious(dto);
                return;
            }

            if (filter.Upcoming)
            {
                UpdateUpcoming(dto);
                return;
            }
        }

        public void Delete(int id, FixedCostFilterDto filter)
        {
            FixedCost fixedCost = _fixedCostRepository.GetById(id);
            ValidateNull(fixedCost);

            if (filter.Current)
            {
                _fixedCostRepository.Delete(fixedCost);
            }

            if (filter.All)
            {
                IEnumerable<FixedCost> fixedsCost = _fixedCostRepository
                    .Search(x => x.FixedCostCategoryId == fixedCost.FixedCostCategoryId);

                Delete(fixedsCost);
                return;
            }

            if (filter.Previous)
            {
                IEnumerable<FixedCost> fixedsCost = _fixedCostRepository
                    .Search(x => x.FixedCostCategoryId == fixedCost.FixedCostCategoryId
                            && x.DebitDay <= fixedCost.DebitDay);

                Delete(fixedsCost);
                return;
            }

            if (filter.Upcoming)
            {
                IEnumerable<FixedCost> fixedsCost = _fixedCostRepository
                    .Search(x => x.FixedCostCategoryId == fixedCost.FixedCostCategoryId
                            && x.DebitDay >= fixedCost.DebitDay);

                Delete(fixedsCost);
                return;
            }

        }

        private void Delete(IEnumerable<FixedCost> fixedsCost)
        {
            ValidateNull(fixedsCost);
            _fixedCostRepository.DeleteRange(fixedsCost);
        }

        private void ValidateFilter(FixedCostFilterDto filter)
        {
            bool[] options = { filter.Previous, filter.Current, filter.Upcoming, filter.All };
            if (options.Count(x => x == true) > 1)
                throw new BadRequestException("Escolha apenas uma opção. (Previous/Current/Upcoming/All)");

            if (options.Count(x => x == true) == 0)
                throw new BadRequestException("Escolha pelo menos uma opção. (Previous/Current/Upcoming/All)");
        }

        private void ValidateNull(FixedCost variedCostDto)
        {
            if (variedCostDto is null)
                throw new NotFoundException();
        }

        private static void ValidateNull(IEnumerable<FixedCost> variedCostsDto)
        {
            if (variedCostsDto.Any() is false)
                throw new NotFoundException();
        }

        private void GenerateCostsForNextMonths(FixedCostAddRequestDto dto, List<FixedCost> fixedCosts)
        {
            var nextDebitDays = dto.DebitDay.AddMonths(1);
            for (int i = 1; i < dto.Frequency; i++)
            {
                dto.DebitDay = nextDebitDays;
                FixedCost fixedCost2 = _mapper.Map<FixedCost>(dto);
                fixedCosts.Add(fixedCost2);
                nextDebitDays = nextDebitDays.AddMonths(1);
            }
        }

        private void UpdateAll(FixedCostEditRequestDto dto)
        {
            IEnumerable<FixedCost> fixedCosts = _fixedCostRepository
                .Search(x => x.FixedCostCategoryId == dto.FixedCostCategoryId);

            ValidateNull(fixedCosts);

            Update(dto, fixedCosts);
        }

        private void UpdateUpcoming(FixedCostEditRequestDto dto)
        {
            IEnumerable<FixedCost> fixedCosts = _fixedCostRepository
                .Search(x => x.FixedCostCategoryId == dto.FixedCostCategoryId
                        && x.DebitDay >= dto.DebitDay);

            ValidateNull(fixedCosts);

            Update(dto, fixedCosts);
        }

        private void UpdatePrevious(FixedCostEditRequestDto dto)
        {
            IEnumerable<FixedCost> fixedCosts = _fixedCostRepository
                .Search(x => x.FixedCostCategoryId == dto.FixedCostCategoryId
                        && x.DebitDay <= dto.DebitDay);

            ValidateNull(fixedCosts);

            Update(dto, fixedCosts);
        }

        private void UpdateCurrent(int id, FixedCostEditRequestDto dto)
        {
            FixedCost fixedCost = _fixedCostRepository.GetById(id);

            ValidateNull(fixedCost);

            Update(dto, fixedCost);
        }

        private void Update(FixedCostEditRequestDto dto, FixedCost fixedCost)
        {
            _fixedCostCategoryService.Update(fixedCost.FixedCostCategoryId, dto.Description);

            fixedCost.Update(dto.CategoryId, dto.Description, dto.Amount, dto.DebitDay);
            _fixedCostRepository.Update(fixedCost);
        }

        private void Update(FixedCostEditRequestDto dto, IEnumerable<FixedCost> fixedCosts)
        {
            _fixedCostCategoryService.Update(dto.FixedCostCategoryId, dto.Description);

            foreach (var fixedCost in fixedCosts)
            {
                fixedCost.Update(dto.CategoryId, dto.Description, dto.Amount, dto.DebitDay);
            }

            _fixedCostRepository.UpdateRange(fixedCosts);
        }
    }
}
