using ControleFinanceiro.Domain.Entities.Base;
using ControleFinanceiro.Domain.Interfaces.Repositories.Base;
using ControleFinanceiro.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ControleFinanceiro.Infra.Data.Repositories.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        protected readonly DbSet<T> _entity;
        protected readonly ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext context)
        {
            _entity = context.Set<T>();
            _context = context;
        }

        public IEnumerable<T> GetAll()
            => _entity.AsNoTracking().ToList();

        public T GetById(int id)
            => _entity.FirstOrDefault(x => x.Id == id);

        public IEnumerable<T> Search(Expression<Func<T, bool>> predicate)
            => _entity.Where(predicate).ToList();

        public void Add(T obj)
            => _entity.Add(obj);

        public void Update(T obj)
            => _entity.Update(obj);

        public void Delete(T obj)
            => _entity.Remove(obj);
    }
}