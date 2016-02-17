using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PNN.ProductsApp.ProductsDB.DAL
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly ProductContext _context;

        public EfGenericRepository(ProductContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        #region IGenericRepository

        public IEnumerable<T> GetAll()
        {
            var result = _dbSet.ToList();
            return result;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _dbSet.ToListAsync();
            return result;
        }

        public T GetById(int id)
        {
            var result = _dbSet.Find(id);
            return result;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _dbSet.FindAsync(id);
            return result;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            var result = _dbSet.Where(predicate).ToList();
            return result;
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            var result = await _dbSet.Where(predicate).ToListAsync();
            return result;
        }

        public IQueryable<T> AsQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            T entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }

        #endregion IGenericRepository
    }
}
