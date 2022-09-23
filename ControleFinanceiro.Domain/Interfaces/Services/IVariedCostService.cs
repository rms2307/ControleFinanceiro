using ControleFinanceiro.Domain.Dtos.VariedCost;

namespace ControleFinanceiro.Domain.Interfaces.Services
{
    public interface IVariedCostService
    {
        IEnumerable<VariedCostResponseDto> GetAll();
        VariedCostResponseDto GetById(int id);
        int Add(VariedCostRequestDto dto);
        void Update(int id, VariedCostRequestDto dto);
        void Delete(int id);
    }
}