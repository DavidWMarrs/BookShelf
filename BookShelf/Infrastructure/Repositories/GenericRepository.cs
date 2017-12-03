using BookShelf.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookShelf.Infrastructure.Repositories
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(params object[] keyValues);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void SaveChanges();
    }

    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _set;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
        {
            return _set;
        }

        public TEntity Get(params object[] keyValues)
        {
            return _set.Find(keyValues);
        }

        public void Add(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
