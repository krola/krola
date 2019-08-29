using Krola.Core.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Krola.Core.Data
{
    public class Repository<C, T, F> : IRepository<T> 
        where T : class 
        where C : DbContext
        where F : DesignTimeDbContextFactoryBase<C>
    {

        private readonly C _entities;

        public Repository(F dbContextFactory)
        {
            _entities = dbContextFactory.Create();
        }

        public C Context
        {

            get { return _entities; }
        }

        public virtual IQueryable<T> GetAll()
        {
            return _entities.Set<T>();
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            return _entities.Set<T>().Where(predicate);
        }

        public virtual async Task Add(T entity)
        {
            await _entities.Set<T>().AddAsync(entity);
        }

        public virtual void Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            //_entities.Entry(entity).State = System.Data.EntityState.Modified;
        }

        public virtual async Task Save()
        {
            await _entities.SaveChangesAsync();
        }
    }
}
