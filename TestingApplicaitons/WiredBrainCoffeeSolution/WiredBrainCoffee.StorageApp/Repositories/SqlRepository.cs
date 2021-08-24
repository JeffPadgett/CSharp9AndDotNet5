using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.StorageApp.Entities;
using static System.Console;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public SqlRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public void Add(T items)
        {
            _dbSet.Add(items);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }
    }
}
