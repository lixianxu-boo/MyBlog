using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.IRepository
{
    public interface IBaseRepository<TEntity> where TEntity:class,new()
    {
        Task<bool> CreatAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        Task<bool> EditAsync(TEntity entity);
        Task<TEntity> FindAsync(int id);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> func);
        Task<List<TEntity>> QueryAsync();
        Task<List<TEntity>> QueryAsync(Expression<Func<TEntity,bool>> func);
        Task<List<TEntity>> QueryAsync(int page, int size, RefAsync<int> total);
        Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func, int page, int size, RefAsync<int> total);

    }
}
