using ControleFinanceiro.Domain.Dtos.VariedSpend;

namespace ControleFinanceiro.Domain.Interfaces.Services
{
    public interface IVariedSpendService
    {
        IEnumerable<VariedSpendResponseDto> GetAll();
        VariedSpendResponseDto GetById(int id);
        int Add(VariedSpendRequestDto dto);
        void Update(int id, VariedSpendRequestDto dto);
        void Delete(int id);
    }
}