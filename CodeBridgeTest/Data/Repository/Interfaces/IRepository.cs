using System.Linq.Expressions;

namespace CodeBridgeTest.Data.Repository.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetQuery(Expression<Func<T, bool>> expression);

        T Get(Expression<Func<T, bool>> expression);

        Task<T> GetAsync(Expression<Func<T, bool>> expression);

        void Save(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}