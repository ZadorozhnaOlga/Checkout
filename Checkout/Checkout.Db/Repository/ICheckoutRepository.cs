using Checkout.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Db.Repository
{
    public interface ICheckoutRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T entity);
        Task<bool> Delete(int id);
        Task<T> Update(T entity);
    }
}
