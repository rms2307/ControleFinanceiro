using ControleFinanceiro.Domain.Entities.Base;
using System.Linq.Expressions;

namespace ControleFinanceiro.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> Search(Expression<Func<T, bool>> predicate);
        void Add(T obj);
        void Update(T obj);
        void Delete(T obj);
    }
}