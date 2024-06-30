using AutoMapper;
using management_system.Repository.interfaces;
using management_system.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace management_system.Services.Services
{
    public class GenericServices<TDto,TEntity> :IGenericServices<TDto,TEntity> where TEntity : class where TDto : class
    {
        private readonly IGenericRepository<TEntity> _genericRepository;
        private readonly IMapper _mapper;
        public GenericServices(IGenericRepository<TEntity> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public void Update(TDto dto)
        {
            TEntity entity = ToEntity(dto);
            _genericRepository.Update(entity);

        }
        public async Task<bool> Remove(long Id)
        {
            TEntity? entity = await _genericRepository.GetById(Id);
            if (entity is not null)
            {
                _genericRepository.Remove(entity);
                return true;
            }
            else
                return false;
        }
        public  async Task<TEntity> AddAsync(TDto dto)
        {
            TEntity entity = ToEntity(dto);
            if (entity != null)
                return await _genericRepository.AddAsync(entity);
            else
               return null;
        }
        public async Task Delete(Expression<Func<TEntity, bool>> predicate)
        {
            await _genericRepository.Delete(predicate);
        }
        public async Task<List<ResponceModel>> selectListAsync<ResponceModel>(Expression<Func<TEntity, ResponceModel>> selectPredicate, Expression<Func<TEntity, bool>> wherePradicate) where ResponceModel : class
        {
            return await _genericRepository.selectListAsync(selectPredicate, wherePradicate);
        }
        public async Task<ResponceModel?> selectFirstAsync<ResponceModel>(Expression<Func<TEntity, ResponceModel>> selectPredicate, Expression<Func<TEntity, bool>> wherePradicate) where ResponceModel : class
        {
            return await _genericRepository.selectFirstAsync(selectPredicate, wherePradicate);
        }
        public async Task<IEnumerable<TEntity>> GetEntitesListAsync(Expression<Func<TEntity, bool>> wherePredicate)
        {
            return await _genericRepository.GetEntitesListAsync(wherePredicate);
        }
        public async Task<TEntity?> GeEntity(Expression<Func<TEntity, bool>> wherePradicate)
        {
            return await _genericRepository.GetEntity(wherePradicate);
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
        public async Task SaveChagesAsync()
        {
            await _genericRepository.SaveChangesAsync();
        }
    }
}
