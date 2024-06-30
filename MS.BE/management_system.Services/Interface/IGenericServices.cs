using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace management_system.Services.Interface
{
    public interface IGenericServices<TDto,TEntity> where TEntity : class where TDto : class
    {
        void Update(TDto dto);
        Task<bool> Remove(long Id);
        Task<TEntity> AddAsync(TDto dto);
        Task Delete(Expression<Func<TEntity, bool>> predicate);
        Task<List<ResponceModel>> selectListAsync<ResponceModel>(Expression<Func<TEntity, ResponceModel>> selectPredicate, Expression<Func<TEntity, bool>> wherePradicate) where ResponceModel : class;
        Task<ResponceModel?> selectFirstAsync<ResponceModel>(Expression<Func<TEntity, ResponceModel>> selectPredicate, Expression<Func<TEntity, bool>> wherePradicate) where ResponceModel : class;
        Task<IEnumerable<TEntity>> GetEntitesListAsync(Expression<Func<TEntity, bool>> wherePredicate);
        Task<TEntity?> GeEntity(Expression<Func<TEntity, bool>> wherePradicate);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> wherePradicate);
        IEnumerable<TEntity> ToEntity(IEnumerable<TDto> dtoList);
        TEntity ToEntity(TDto Tdto);
        Task SaveChagesAsync();
    }
}
