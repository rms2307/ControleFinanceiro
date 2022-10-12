using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using ControleFinanceiro.Infra.Data.Context;
using ControleFinanceiro.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Infra.Data.Repositories
{
    public class CreditCardRepository : RepositoryBase<CreditCard>, ICreditCardRepository
    {
        public CreditCardRepository(ApplicationDbContext context) : base(context) { }

        public override CreditCard GetById(int id)
        {
            return _entity
                 .Include(x => x.CreditCardSpends)
                 .ThenInclude(x => x.CreditCardSpendInstallments)
                 .Include(x => x.CreditCardSpends)
                 .ThenInclude(x => x.Category)
                 .FirstOrDefault(x => x.Id == id)!;
        }
    }
}