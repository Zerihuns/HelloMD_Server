using HelloMD.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using NameAPIProxyService.Data;
using System.Linq.Expressions;

namespace HelloMD.Repositories
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        
        protected readonly IDbContextFactory<HelloMDDbContext> _context;
        protected readonly HelloMDDbContext _contextFactory;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(IDbContextFactory<HelloMDDbContext> context)
        {
            _contextFactory = context.CreateDbContext();
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.CreateDbContext().Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return _dbSet.AsNoTracking().AsEnumerable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

  
        public T Update(T entity)
        {
            var result = _dbSet.Update(entity);
            return result.Entity;
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }


    }
}

