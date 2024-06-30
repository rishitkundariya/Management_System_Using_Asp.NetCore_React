using management_system.Entities.DataModels;
using management_system.Repository.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
        }
        public  void Remove(TEntity entity)
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
        public async Task<List<TDto>> selectListAsync<TDto>(Expression<Func<TEntity, TDto>> selectPredicate, Expression<Func<TEntity, bool>> wherePradicate) where TDto : class
        {
            return await  _dbSet.Where(wherePradicate).Select(selectPredicate).ToListAsync();
        }
        public async Task<TDto?> selectFirstAsync<TDto>(Expression<Func<TEntity, TDto>> selectPredicate, Expression<Func<TEntity, bool>> wherePradicate) where TDto : class
        {
            return await _dbSet.Where(wherePradicate).Select(selectPredicate).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<TEntity>> GetEntitesListAsync(Expression<Func<TEntity, bool>> wherePredicate )
        {
            return await _dbSet.Where(wherePredicate).ToListAsync();
        }
        public async Task<TEntity?> GetEntity(Expression<Func<TEntity, bool>> wherePradicate)
        {
            return await _dbSet.Where(wherePradicate).FirstOrDefaultAsync();
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
    }
}
