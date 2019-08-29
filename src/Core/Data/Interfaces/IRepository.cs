using Krola.Domain.Shared;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Krola.Core.Data.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        Task Save();
    }
}
