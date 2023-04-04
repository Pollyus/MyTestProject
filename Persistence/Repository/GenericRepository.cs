﻿using Application.Common.Interfaces;
using Persistence.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        private readonly TestAppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(TestAppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetList()
        {
            return _dbSet;
        }

        public virtual TEntity? GetByID(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public virtual void Update()
        {
            _context.SaveChanges();
        }
    }
}
