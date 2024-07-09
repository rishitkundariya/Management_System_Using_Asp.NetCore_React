using management_system.Entities.DataModels;
using management_system.Shared.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace management_system.Services.Interface
{
    public interface IGenericServices<TDto,TEntity> where TEntity : BaseEntity where TDto : class
    {
        Task Update(TDto dto, long Id);
        Task<bool> Remove(long Id);
        Task<TEntity> AddAsync(TDto dto);
        Task Delete(Expression<Func<TEntity, bool>> predicate);
        Task<object?> selectListAsync(Expression<Func<TEntity, object>> selectPredicate, Expression<Func<TEntity, bool>> wherePradicate, Expression<Func<TEntity, dynamic>> orderByPradicate);
        Task<object?> selectFirstAsync(Expression<Func<TEntity, object>> selectPredicate, Expression<Func<TEntity, bool>> wherePradicate);
        Task<IEnumerable<TEntity>> GetEntitesListAsync(Expression<Func<TEntity, bool>> wherePredicate);
        Task<TEntity?> GeEntity(Expression<Func<TEntity, bool>> wherePradicate);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> wherePradicate);
        IEnumerable<TEntity> ToEntity(IEnumerable<TDto> dtoList);
        TEntity ToEntity(TDto Tdto);
        Task SaveChagesAsync();
        Task<SearchResponce> GetPaginatedListAsync(Expression<Func<TEntity, object>> selectPredicate, Expression<Func<TEntity, bool>> wherePradicate, Expression<Func<TEntity, dynamic>> orderByPradicate, int pageSize, int pageNo, string sortDir);
    }
}
