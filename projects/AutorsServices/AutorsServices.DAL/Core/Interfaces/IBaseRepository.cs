using System.Linq.Expressions;

namespace AutorsServices.DAL.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        void DeleteAsync(T entity);
        Task<bool> ExitsAsync(Expression<Func<T, bool>> whereExpression);
        Task<List<T>> GetAllAsync(PaginationArguments paginationArguments, bool tracked = true, Expression<Func<T, bool>>? whereExpression = null, Expression<Func<T, object>>? includeExpression = null, Expression<Func<T, object>>? orderExpression = null);
        Task<T?> GetAsync(bool tracked = true, Expression<Func<T, bool>>? whereExpression = null);
        void UpdateAsync(T entity);
    }
}
