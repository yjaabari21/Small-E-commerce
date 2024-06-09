using System.Linq;

namespace HelloWorld.Services
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(params object[] pks);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}