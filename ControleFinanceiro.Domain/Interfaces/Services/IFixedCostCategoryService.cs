using ControleFinanceiro.Domain.Dtos.FixedCost;

namespace ControleFinanceiro.Domain.Interfaces.Services
{
    public interface IFixedCostCategoryService
    {
        int Add(string name);

        void Update(int id, string name);
    }
}