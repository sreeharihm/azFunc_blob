using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskApp.Data.Interface;
using TaskApp.Data.Model;

namespace TaskApp.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private ITaskDbContext _context;
        private DbSet<T> table;


        public Repository(ITaskDbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }

        public async Task Create(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                table.Add(entity);
                await _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => _context.Set<T>().Where(expression);

    }
}
