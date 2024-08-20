using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Data.Interface
{
    public interface IRepository<T>
    {
        Task Create(T entity);

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    }
}
