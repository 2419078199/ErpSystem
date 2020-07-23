﻿using Model.Entitys;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IBaseRepository<T> where T : class
    {
        DB_ERPContext DbErpContext { get; set; }

        void AddEntityAsync(T entity);

        void DeleteEntity(T entity);

        void EditEntity(T entity);

        Task<bool> ExistEntityAsync(Expression<Func<T, bool>> whereLamda);

        Task<T> GetEntityByIdAsync(int id);

        IQueryable<T> GetEntitys();

        IQueryable<T> GetEntitys(Expression<Func<T, bool>> whereLamda);

        Task<bool> SaveChangesAsync();
    }
}