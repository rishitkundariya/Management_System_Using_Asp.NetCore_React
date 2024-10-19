using management_system.Entities.Dtos;
using management_system.Entities.DataModels;
using management_system.Repository.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using management_system.Shared.Utilities;
using management_system.Shared.Constants;

namespace management_system.Repository.Reposotories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly AppDbContext _dbContext;
        public GenericRepository(AppDbContext appDbContext)
        {
            _dbSet = appDbContext.Set<TEntity>();
            _dbContext = appDbContext;
        }
        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();

        }
        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task Delete(Expression<Func<TEntity, bool>> predicate)
        {
            await _dbSet.Where(predicate).ExecuteDeleteAsync();
        }
        public async Task<object?> selectListAsync(Expression<Func<TEntity, object>> selectPredicate, Expression<Func<TEntity, bool>> wherePradicate, Expression<Func<TEntity, dynamic>> orderByPradicate)
        {
            var result = _dbSet.AsQueryable();
            if (wherePradicate != null)
            {
                result = result.Where(wherePradicate);
            }
            if (orderByPradicate != null)
            {
                result = result.OrderBy(orderByPradicate);
            }
            return await result.Select(selectPredicate).ToListAsync();
        }
        public async Task<object?> selectFirstAsync(Expression<Func<TEntity, object>> selectPredicate, Expression<Func<TEntity, bool>> wherePradicate)
        {
            if (selectPredicate == null)
            {
                return await _dbSet.Where(wherePradicate).FirstOrDefaultAsync();
            }
            else if (wherePradicate == null)
            {
                return await _dbSet.Select(selectPredicate).FirstOrDefaultAsync();
            }
            else
            {
                return await _dbSet.Where(wherePradicate).Select(selectPredicate).FirstOrDefaultAsync();
            }

        }
        public async Task<IEnumerable<TEntity>> GetEntitesListAsync(Expression<Func<TEntity, bool>> wherePredicate)
        {
            return await _dbSet.Where(wherePredicate).ToListAsync();
        }
        public async Task<TEntity?> GetEntity(Expression<Func<TEntity, bool>> wherePradicate)
        {
            return await _dbSet.Where(wherePradicate).FirstOrDefaultAsync();
        }
         public async Task<object?> GetEntity(Expression<Func<TEntity, bool>> wherePradicate,Expression<Func<TEntity, object>> selectPredicate)
        {
            return await _dbSet.Where(wherePradicate).Select(selectPredicate).FirstOrDefaultAsync();
        }
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> wherePradicate)
        {
            return await _dbSet.AnyAsync(wherePradicate);
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task<TEntity?> GetById(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<SearchResponce> GetPaginatedListAsync(Expression<Func<TEntity, object>> selectPredicate, Expression<Func<TEntity, bool>> wherePradicate, Expression<Func<TEntity, dynamic>> orderByPradicate, int pageSize, int pageNo, string sortDir)
        {
            var result = _dbSet.AsQueryable();
            if (wherePradicate != null)
            {
                result = result.Where(wherePradicate);
            }
            if (orderByPradicate != null)
            {
                if (sortDir.ToUpper() == SystemConstants.DESCENDING)
                {
                    result = result.OrderByDescending(orderByPradicate);
                }
                else
                {
                    result = result.OrderBy(orderByPradicate);
                }
            }
            return new SearchResponce {
                TotalCount = await result.CountAsync(),
                SearchData = await result.Select(selectPredicate).Skip(pageSize * (pageNo - 1)).Take(pageSize).ToListAsync()
            };
        }
    }
}
