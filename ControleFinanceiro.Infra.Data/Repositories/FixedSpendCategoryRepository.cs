using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using ControleFinanceiro.Infra.Data.Context;
using ControleFinanceiro.Infra.Data.Repositories.Base;

namespace ControleFinanceiro.Infra.Data.Repositories
{
    public class FixedSpendCategoryRepository : RepositoryBase<FixedSpendCategory>, IFixedSpendCategoryRepository
    {
        public FixedSpendCategoryRepository(ApplicationDbContext context) : base(context) { }
    }
}