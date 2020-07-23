using IRepository;
using Microsoft.EntityFrameworkCore;
using Model.Entitys;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public BaseRepository(DB_ERPContext dbErpContext)
        {
            DbErpContext = dbErpContext;
        }

        public DB_ERPContext DbErpContext { get; set; }

        public async void AddEntityAsync(T entity)
        {
            await DbErpContext.Set<T>().AddAsync(entity);
        }

        public void DeleteEntity(T entity)
        {
            DbErpContext.Entry(entity).State = EntityState.Deleted;
        }

        public void EditEntity(T entity)
        {
            DbErpContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task<bool> ExistEntityAsync(Expression<Func<T, bool>> whereLamda)
        {
            return await DbErpContext.Set<T>().AnyAsync(whereLamda);
        }

        //Task<T> IBaseRepository<T>.GetEntityByIdAsync(int id)
        //{
        //    return GetEntityByIdAsync(id);
        //}

        //IQueryable<T> IBaseRepository<T>.GetEntitys()
        //{
        //    return GetEntitys();
        //}

        public IQueryable<T> GetEntitys(Expression<Func<T, bool>> whereLamda)
        {
            return DbErpContext.Set<T>().Where(whereLamda);
        }

        //Task<bool> IBaseRepository<T>.SaveChangesAsync()
        //{
        //    return SaveChangesAsync();
        //}

        public async Task<T> GetEntityByIdAsync(int id)
        {
            return await DbErpContext.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetEntitys()
        {
            return DbErpContext.Set<T>();
        }

        public async Task<bool> SaveChangesAsync()
        {
            var count = await DbErpContext.SaveChangesAsync();
            return count > 0;
        }
    }
}