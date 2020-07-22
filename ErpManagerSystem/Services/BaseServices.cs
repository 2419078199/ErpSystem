using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IRepository;
using IServices;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class BaseServices<T> : IBaseServices<T> where T : class
    {
        public IBaseRepository<T> CurrentRepository { get; set; }

        public BaseServices()
        {

        }

        public async Task<bool> DeleteEntityByIdAsync(int id)
        {
            T entity = await CurrentRepository.GetEntityByIdAsync(id);
            CurrentRepository.DeleteEntity(entity);
            return await CurrentRepository.SaveChangesAsync();
        }
        public async Task<bool> AddEntityAsync(T entity)
        {
            this.CurrentRepository.AddEntityAsync(entity);
            return await CurrentRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteEntityAsync(T entity)
        {
            this.CurrentRepository.DeleteEntity(entity);
            return await CurrentRepository.SaveChangesAsync();
        }

        public async Task<bool> EditEntityAsync(T entity)
        {
            this.CurrentRepository.EditEntity(entity);
            return await CurrentRepository.SaveChangesAsync();
        }

        public async Task<bool> ExistEntityAsync(Expression<Func<T, bool>> whereLamda)
        {
            return await this.CurrentRepository.ExistEntityAsync(whereLamda);
        }

        public async Task<T> GetEntityByIdAsync(int id)
        {
            return await this.CurrentRepository.GetEntityByIdAsync(id);
        }

        public IQueryable<T> GetEntitys(Expression<Func<T, bool>> whereLamda)
        {
            return this.CurrentRepository.GetEntitys(whereLamda);
        }

        public IQueryable<T> GetEntitys()
        {
            return this.CurrentRepository.GetEntitys();
        }

    }
}