

using Microsoft.EntityFrameworkCore;

namespace TaskApp.Data.Interface
{
    public interface ITaskDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChanges();
    }
}
