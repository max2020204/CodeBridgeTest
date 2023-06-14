using CodeBridgeTest.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CodeBridgeTest.Data.Repository.Implement
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        protected AppDbContext context { get; set; }
        public EFRepository(AppDbContext _context)
        {
            context = _context;
        }
        public virtual void Delete(T entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public virtual T Get(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().FirstOrDefault(expression);
        }
        public virtual IQueryable<T> GetAll()
        {
            return context.Set<T>().AsSplitQuery();
        }
        public virtual IQueryable<T> GetQuery(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().AsSplitQuery().Where(expression);
        }
        public virtual void Save(T entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }
        public virtual void Update(T entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }

        public Task<T?> GetAsync(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().FirstOrDefaultAsync(expression);
        }
    }
}
