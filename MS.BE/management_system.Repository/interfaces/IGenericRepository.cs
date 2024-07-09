using management_system.Shared.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace management_system.Repository.interfaces
{
    public interface IGenericRepository<TEntity> where TEntity  : class
    {
        void Update(TEntity entity);
        void Remove(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        Task Delete(Expression<Func<TEntity, bool>> predicate);
        Task<object?> selectListAsync(Expression<Func<TEntity, object>> selectPredicate, Expression<Func<TEntity, bool>> wherePradicate, Expression<Func<TEntity, dynamic>> orderByPradicate);
        Task<object?> selectFirstAsync(Expression<Func<TEntity, object>> selectPredicate, Expression<Func<TEntity, bool>> wherePradicate);
        Task<IEnumerable<TEntity>> GetEntitesListAsync(Expression<Func<TEntity, bool>> wherePredicate );
        Task<TEntity?> GetEntity(Expression<Func<TEntity, bool>> wherePradicate);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> wherePradicate);
        Task SaveChangesAsync();
        Task<TEntity?> GetById(long id);
        Task<SearchResponce> GetPaginatedListAsync(Expression<Func<TEntity, object>> selectPredicate, Expression<Func<TEntity, bool>> wherePradicate, Expression<Func<TEntity, dynamic>> orderByPradicate, int pageSize, int pageNo, string sortDir);
    }
}
