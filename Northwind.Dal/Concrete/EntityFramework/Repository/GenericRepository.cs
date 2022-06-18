﻿using Microsoft.EntityFrameworkCore;
using Northwind.Dal.Abstract;
using Northwind.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Dal.Concrete.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        #region Variables
        protected DbContext context;
        protected DbSet<T> dbset;
        #endregion
        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.dbset = this.context.Set<T>();
            // Lazy loading: bağlı olan tüm tabloları çeker. Aşağıdaki kod açıksa Lazy loading çalışmaz. 16.02.2022
            // Eager Loading:
            //this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public T Add(T item)
        {
            context.Entry(item).State = EntityState.Added;
            dbset.Add(item);

            return item;
        }

        public async Task<T> AddAsync(T item)
        {
            context.Entry(item).State = EntityState.Added;
            await dbset.AddAsync(item);

            return item;
        }

        public bool Delete(int id)
        {
            return Delete(Find(id));
        }

        public bool Delete(T item)
        {
            if (context.Entry(item).State == EntityState.Detached)
            {
                context.Attach(item);
            }
            return dbset.Remove(item) != null;
        }


        public T Find(int id)
        {
            return dbset.Find(id);
        }

        public List<T> GetAll()
        {
            return dbset.ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return dbset.Where(expression).ToList();
        }

        public IQueryable<T> GetQueryable()
        {
            return dbset.AsQueryable();
        }

        public T Update(T item)
        {
            dbset.Update(item);
            return item;
        }

    }
}