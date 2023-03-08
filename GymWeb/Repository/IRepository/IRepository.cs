using System.Linq.Expressions;

namespace GymWeb.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //Glowne funkcje Repository
        void Add(T entity);
        void Remove(T entity);
        T GetFirstOfDefault(Expression<Func<T,bool>>? filter=null);
        IEnumerable<T> GetAll();
    }
}
