using AutoMapper;
using management_system.Repository.interfaces;
using management_system.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using management_system.Shared.Exceptions;
using management_system.Shared.Constants;
using management_system.Entities.DataModels;
using management_system.Shared.Utilities;

namespace management_system.Services.Services
{
    public class GenericServices<TDto,TEntity> :IGenericServices<TDto,TEntity> where TEntity : BaseEntity where TDto : class
    {
        private readonly IGenericRepository<TEntity> _genericRepository;
        private readonly IMapper _mapper;
        public GenericServices(IGenericRepository<TEntity> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task Update(TDto dto,long Id)
        {

            TEntity? entity = await _genericRepository.GetById(Id);
            if (entity is not null)
            {
                entity = ToEntity(dto, entity);
                entity.UpdatedAt = DateTime.UtcNow;
                _genericRepository.Update(entity);
            }
            else
                throw new NotFoundException(SystemConstants.NoRecordsFound);

        }
        public async Task<bool> Remove(long Id)
        {
            TEntity? entity = await _genericRepository.GetById(Id);
            if (entity is not null)
            {
                entity.DeletedAt = DateTime.UtcNow;
                entity.IsDeleted = true;
                _genericRepository.Update(entity);
                return true;
            }
            else
                throw new NotFoundException(SystemConstants.NoRecordsFound);
        }
        public  async Task<TEntity> AddAsync(TDto dto)
        {
            TEntity entity = ToEntity(dto);
            if (entity != null)
            {
                entity.CreatedAt = DateTime.UtcNow;
                return await _genericRepository.AddAsync(entity);
            }
            else
                throw new NullReferenceException();
        }
        public async Task Delete(Expression<Func<TEntity, bool>> predicate)
        {
            await _genericRepository.Delete(predicate);
        }
        public async Task<object?> selectListAsync(Expression<Func<TEntity, object>> selectPredicate, Expression<Func<TEntity, bool>> wherePradicate, Expression<Func<TEntity, dynamic>> orderByPradicate) 
        {
            return await _genericRepository.selectListAsync(selectPredicate, wherePradicate, orderByPradicate);
        }
        public async Task<object?> selectFirstAsync(Expression<Func<TEntity, object>> selectPredicate, Expression<Func<TEntity, bool>> wherePradicate)
        {
            return await _genericRepository.selectFirstAsync(selectPredicate, wherePradicate);
        }
        public async Task<IEnumerable<TEntity>> GetEntitesListAsync(Expression<Func<TEntity, bool>> wherePredicate)
        {
            return await _genericRepository.GetEntitesListAsync(wherePredicate);
        }
        public async Task<TEntity?> GetEntity(Expression<Func<TEntity, bool>> wherePradicate)
        {
            return await _genericRepository.GetEntity(wherePradicate);
        }
        public async Task<object?> GetEntity(Expression<Func<TEntity, bool>> wherePradicate,Expression<Func<TEntity, object>> selectPredicate)
        {
            return await _genericRepository.GetEntity(wherePradicate,selectPredicate);
        }
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> wherePradicate)
        {
            return await _genericRepository.AnyAsync(wherePradicate);
        }
        public IEnumerable<TEntity> ToEntity(IEnumerable<TDto> dtoList)
        {
            IEnumerable<TEntity> entityList = _mapper.Map<IEnumerable<TDto>, IEnumerable<TEntity>>(dtoList);
            return entityList;
        }
        public  TEntity ToEntity(TDto Tdto)
        {
            TEntity entity = _mapper.Map<TDto, TEntity>(Tdto);
            return entity;
        }
        public TEntity ToEntity(TDto Tdto,TEntity entity)
        {
            return  _mapper.Map(Tdto,entity);
        }
        public async Task SaveChagesAsync()
        {
            await _genericRepository.SaveChangesAsync();
        }
        public async Task<SearchResponce> GetPaginatedListAsync(Expression<Func<TEntity, object>> selectPredicate, Expression<Func<TEntity, bool>> wherePradicate, Expression<Func<TEntity, dynamic>> orderByPradicate, int pageSize, int pageNo, string sortDir)
        {
           return await _genericRepository.GetPaginatedListAsync(selectPredicate,wherePradicate,orderByPradicate,pageSize,pageNo,sortDir);
        }
    }
}
