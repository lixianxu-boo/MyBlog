using MyBlog.IBaseService;
using MyBlog.IRepository;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BaseService
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        protected IBaseRepository<TEntity> _iBaseRepository;

        //public BaseService(IBaseRepository<TEntity> iBaseRepository)
        //{
        //    _iBaseRepository = iBaseRepository;
        //}
        public async Task<bool> CreatAsync(TEntity entity)
        {
            return await _iBaseRepository.CreatAsync(entity);
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            return await _iBaseRepository.DeleteAsync(entity);
        }

        public async Task<bool> EditAsync(TEntity entity)
        {
            return await _iBaseRepository.EditAsync(entity);
        }

        public async Task<TEntity> FindAsync(int id)
        {
            return await _iBaseRepository.FindAsync(id);
        }

        public async Task<List<TEntity>> QueryAsync()
        {
            return await _iBaseRepository.QueryAsync();
        }

        public async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func)
        {
            return await _iBaseRepository.QueryAsync(func);
        }

        public async Task<List<TEntity>> QueryAsync(int page, int size, RefAsync<int> total)
        {
            return await _iBaseRepository.QueryAsync(page, size, total);
        }

        public async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func, int page, int size, RefAsync<int> total)
        {
            return await _iBaseRepository.QueryAsync(func, page, size, total);
        }
    }
}
