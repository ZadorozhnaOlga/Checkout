using Checkout.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Db.Repository
{
    public interface ITransactionRepository : ICheckoutRepository<Transaction>
    {
    }
    public class TransactionRepository : CheckoutRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(CheckoutDbContext dbContext) : base(dbContext)
        {

        }
    }
}
