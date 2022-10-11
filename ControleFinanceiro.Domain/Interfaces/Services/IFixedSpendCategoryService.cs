namespace ControleFinanceiro.Domain.Interfaces.Services
{
    public interface IFixedSpendCategoryService
    {
        int Add(string name);

        void Update(int id, string name);
    }
}