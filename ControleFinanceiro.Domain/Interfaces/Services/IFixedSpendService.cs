using ControleFinanceiro.Domain.Dtos.FixedSpend;

namespace ControleFinanceiro.Domain.Interfaces.Services
{
    public interface IFixedSpendService
    {
        IEnumerable<FixedSpendResponseDto> GetAll();
        FixedSpendResponseDto GetById(int id);
        void Add(FixedSpendAddRequestDto dto);
        void Update(int id, FixedSpendEditRequestDto dto, FixedSpendFilterDto filter);
        void Delete(int id, FixedSpendFilterDto filter);
    }
}