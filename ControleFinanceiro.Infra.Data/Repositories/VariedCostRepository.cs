using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using ControleFinanceiro.Infra.Data.Context;
using ControleFinanceiro.Infra.Data.Repositories.Base;

namespace ControleFinanceiro.Infra.Data.Repositories
{
    public class VariedCostRepository : RepositoryBase<VariedCost>, IVariedCostRepository
    {
        public VariedCostRepository(ApplicationDbContext context) : base(context) { }
    }
}