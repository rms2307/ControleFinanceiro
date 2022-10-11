using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using ControleFinanceiro.Domain.Interfaces.Services;

namespace ControleFinanceiro.Application.Services
{
    public class FixedSpendCategoryService : IFixedSpendCategoryService
    {
        private readonly IFixedSpendCategoryRepository _fixedSpendCategoryRepository;

        public FixedSpendCategoryService(IFixedSpendCategoryRepository fixedSpendCategoryRepository)
        {
            _fixedSpendCategoryRepository = fixedSpendCategoryRepository;
        }

        public int Add(string name)
        {
            FixedSpendCategory fixedSpendCategory = new(name);

            _fixedSpendCategoryRepository.Add(fixedSpendCategory);

            return fixedSpendCategory.Id;
        }

        public void Update(int id, string name)
        {
            FixedSpendCategory fixedSpendCategory = _fixedSpendCategoryRepository.GetById(id);
            fixedSpendCategory.Update(name);

            _fixedSpendCategoryRepository.Update(fixedSpendCategory);
        }
    }
}
