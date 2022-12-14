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

        public virtual T GetById(int id)
            => _entity.FirstOrDefault(x => x.Id == id)!;

        public IEnumerable<T> Search(Expression<Func<T, bool>> predicate)
            => _entity.Where(predicate).ToList();

        public void Add(T obj)
        {
            _entity.Add(obj);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<T> obj)
        {
            _entity.AddRange(obj);
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            _entity.Update(obj);
            _context.SaveChanges();
        }

        public void UpdateRange(IEnumerable<T> obj)
        {
            _entity.UpdateRange(obj);
            _context.SaveChanges();
        }

        public void Delete(T obj)
        {
            _entity.Remove(obj);
            _context.SaveChanges();
        }

        public void DeleteRange(IEnumerable<T> obj)
        {
            _entity.RemoveRange(obj);
            _context.SaveChanges();
        }
    }
}