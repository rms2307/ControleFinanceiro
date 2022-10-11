using AutoMapper;
using ControleFinanceiro.Domain.Dtos.FixedSpend;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Exceptions;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using ControleFinanceiro.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace ControleFinanceiro.Application.Services
{
    public class FixedSpendService : IFixedSpendService
    {
        private readonly IMapper _mapper;
        private readonly IFixedSpendtRepository _fixedSpendRepository;
        private readonly IFixedSpendCategoryService _fixedSpendCategoryService;

        public FixedSpendService(IMapper mapper, IFixedSpendtRepository fixedSpendRepository,
            IFixedSpendCategoryService fixedSpendCategoryService)
        {
            _mapper = mapper;
            _fixedSpendRepository = fixedSpendRepository;
            _fixedSpendCategoryService = fixedSpendCategoryService;
        }

        public IEnumerable<FixedSpendResponseDto> GetAll()
            => _mapper.Map<IEnumerable<FixedSpendResponseDto>>(_fixedSpendRepository.GetAll());

        public FixedSpendResponseDto GetById(int id)
        {
            FixedSpend fixedSpend = _fixedSpendRepository.GetById(id);
            ValidateNull(fixedSpend);

            return _mapper.Map<FixedSpendResponseDto>(fixedSpend);
        }

        public void Add(FixedSpendAddRequestDto dto)
        {
            List<FixedSpend> fixedSpends = new();

            dto.FixedSpendCategoryId = _fixedSpendCategoryService.Add(dto.Description);

            FixedSpend fixedSpend = _mapper.Map<FixedSpend>(dto);
            fixedSpends.Add(fixedSpend);

            if (dto.Frequency > 1)
                GenerateSpendsForNextMonths(dto, fixedSpends);

            _fixedSpendRepository.AddRange(fixedSpends);
        }

        public void Update(int id, FixedSpendEditRequestDto dto, FixedSpendFilterDto filter)
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

        public void Delete(int id, FixedSpendFilterDto filter)
        {
            FixedSpend fixedSpend = _fixedSpendRepository.GetById(id);
            ValidateNull(fixedSpend);

            if (filter.Current)
            {
                _fixedSpendRepository.Delete(fixedSpend);
            }

            if (filter.All)
            {
                IEnumerable<FixedSpend> fixedsSpend = _fixedSpendRepository
                    .Search(x => x.FixedSpendCategoryId == fixedSpend.FixedSpendCategoryId);

                Delete(fixedsSpend);
                return;
            }

            if (filter.Previous)
            {
                IEnumerable<FixedSpend> fixedsSpend = _fixedSpendRepository
                    .Search(x => x.FixedSpendCategoryId == fixedSpend.FixedSpendCategoryId
                            && x.DebitDay <= fixedSpend.DebitDay);

                Delete(fixedsSpend);
                return;
            }

            if (filter.Upcoming)
            {
                IEnumerable<FixedSpend> fixedsSpend = _fixedSpendRepository
                    .Search(x => x.FixedSpendCategoryId == fixedSpend.FixedSpendCategoryId
                            && x.DebitDay >= fixedSpend.DebitDay);

                Delete(fixedsSpend);
                return;
            }

        }

        private void Delete(IEnumerable<FixedSpend> fixedsSpend)
        {
            ValidateNull(fixedsSpend);
            _fixedSpendRepository.DeleteRange(fixedsSpend);
        }

        private void ValidateFilter(FixedSpendFilterDto filter)
        {
            bool[] options = { filter.Previous, filter.Current, filter.Upcoming, filter.All };
            if (options.Count(x => x == true) > 1)
                throw new BadRequestException("Escolha apenas uma opção. (Previous/Current/Upcoming/All)");

            if (options.Count(x => x == true) == 0)
                throw new BadRequestException("Escolha pelo menos uma opção. (Previous/Current/Upcoming/All)");
        }

        private void ValidateNull(FixedSpend variedSpendDto)
        {
            if (variedSpendDto is null)
                throw new NotFoundException();
        }

        private static void ValidateNull(IEnumerable<FixedSpend> variedSpendsDto)
        {
            if (variedSpendsDto.Any() is false)
                throw new NotFoundException();
        }

        private void GenerateSpendsForNextMonths(FixedSpendAddRequestDto dto, List<FixedSpend> fixedSpends)
        {
            var nextDebitDays = dto.DebitDay.AddMonths(1);
            for (int i = 1; i < dto.Frequency; i++)
            {
                dto.DebitDay = nextDebitDays;
                FixedSpend fixedSpend2 = _mapper.Map<FixedSpend>(dto);
                fixedSpends.Add(fixedSpend2);
                nextDebitDays = nextDebitDays.AddMonths(1);
            }
        }

        private void UpdateAll(FixedSpendEditRequestDto dto)
        {
            IEnumerable<FixedSpend> fixedSpends = _fixedSpendRepository
                .Search(x => x.FixedSpendCategoryId == dto.FixedSpendCategoryId);

            ValidateNull(fixedSpends);

            Update(dto, fixedSpends);
        }

        private void UpdateUpcoming(FixedSpendEditRequestDto dto)
        {
            IEnumerable<FixedSpend> fixedSpends = _fixedSpendRepository
                .Search(x => x.FixedSpendCategoryId == dto.FixedSpendCategoryId
                        && x.DebitDay >= dto.DebitDay);

            ValidateNull(fixedSpends);

            Update(dto, fixedSpends);
        }

        private void UpdatePrevious(FixedSpendEditRequestDto dto)
        {
            IEnumerable<FixedSpend> fixedSpends = _fixedSpendRepository
                .Search(x => x.FixedSpendCategoryId == dto.FixedSpendCategoryId
                        && x.DebitDay <= dto.DebitDay);

            ValidateNull(fixedSpends);

            Update(dto, fixedSpends);
        }

        private void UpdateCurrent(int id, FixedSpendEditRequestDto dto)
        {
            FixedSpend fixedSpend = _fixedSpendRepository.GetById(id);

            ValidateNull(fixedSpend);

            Update(dto, fixedSpend);
        }

        private void Update(FixedSpendEditRequestDto dto, FixedSpend fixedSpend)
        {
            _fixedSpendCategoryService.Update(fixedSpend.FixedSpendCategoryId, dto.Description);

            fixedSpend.Update(dto.CategoryId, dto.Description, dto.Amount, dto.DebitDay);
            _fixedSpendRepository.Update(fixedSpend);
        }

        private void Update(FixedSpendEditRequestDto dto, IEnumerable<FixedSpend> fixedSpends)
        {
            _fixedSpendCategoryService.Update(dto.FixedSpendCategoryId, dto.Description);

            foreach (var fixedSpend in fixedSpends)
            {
                fixedSpend.Update(dto.CategoryId, dto.Description, dto.Amount, dto.DebitDay);
            }

            _fixedSpendRepository.UpdateRange(fixedSpends);
        }
    }
}
