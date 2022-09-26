using ControleFinanceiro.Domain.Dtos.FixedCost;

namespace ControleFinanceiro.Domain.Interfaces.Services
{
    public interface IFixedCostService
    {
        IEnumerable<FixedCostResponseDto> GetAll();
        FixedCostResponseDto GetById(int id);
        void Add(FixedCostRequestDto dto);
        void Update(int id, FixedCostEditRequestDto dto, FixedCostFilterDto filter);
        void Delete(int id);
    }
}