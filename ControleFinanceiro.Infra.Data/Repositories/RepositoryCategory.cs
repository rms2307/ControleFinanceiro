using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Infra.Data.Context;
using ControleFinanceiro.Infra.Data.Repositories.Base;

namespace ControleFinanceiro.Infra.Data.Repositories
{
    internal class RepositoryCategory : RepositoryBase<Category>, ICategoryRepository
    {
        public RepositoryCategory(ApplicationDbContext context) : base(context) { }
    }
}