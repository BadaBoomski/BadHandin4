﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProsumerInfo.Interface;
using ProsumerInfo.Models;

namespace ProsumerInfo.Repo
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ProsumerDbContext Context;

        public Repository(ProsumerDbContext context)
        {
            Context = context;
        }


        public void Create(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public TEntity GetByID(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }
    }
}
