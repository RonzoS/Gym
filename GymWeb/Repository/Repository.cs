using GymWeb.Data;
using GymWeb.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GymWeb.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet=db.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if(includeProperties != null)
            {
                foreach (var includePropery in includeProperties.Split(
                    new char[] {','}, StringSplitOptions.RemoveEmptyEntries)) 
                { 
                    query = query.Include(includePropery);
                }
            }
            return query.ToList();
        }

        public T GetFirstOfDefault(Expression<Func<T, bool>>? filter)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
