using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using ControleFinanceiro.Infra.Data.Context;
using ControleFinanceiro.Infra.Data.Repositories.Base;

namespace ControleFinanceiro.Infra.Data.Repositories
{
    public class FixedCostRepository : RepositoryBase<FixedCost>, IFixedCostRepository
    {
        public FixedCostRepository(ApplicationDbContext context) : base(context) { }
    }
}