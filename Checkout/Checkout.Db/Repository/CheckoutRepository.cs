using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Db.Repository
{
    public abstract class CheckoutRepository<T> : ICheckoutRepository<T> where T : class
    {
        protected readonly CheckoutDbContext _dbContext;

        protected CheckoutRepository(CheckoutDbContext context)
        {
            _dbContext = context;
        }

        public async Task<T> Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync<T>();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges();

            return entity;
        }
    }
}
