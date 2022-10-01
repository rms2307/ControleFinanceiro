using AutoMapper;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using ControleFinanceiro.Domain.Interfaces.Services;

namespace ControleFinanceiro.Application.Services
{
    public class FixedCostCategoryService : IFixedCostCategoryService
    {
        private readonly IFixedCostCategoryRepository _fixedCostCategoryRepository;

        public FixedCostCategoryService(IFixedCostCategoryRepository fixedCostCategoryRepository)
        {
            _fixedCostCategoryRepository = fixedCostCategoryRepository;
        }

        public int Add(string name)
        {
            FixedCostCategory fixedCostCategory = new(name);

            _fixedCostCategoryRepository.Add(fixedCostCategory);

            return fixedCostCategory.Id;
        }

        public void Update(int id, string name)
        {
            FixedCostCategory fixedCostCategory = _fixedCostCategoryRepository.GetById(id);
            fixedCostCategory.Update(name);

            _fixedCostCategoryRepository.Update(fixedCostCategory);
        }
    }
}
