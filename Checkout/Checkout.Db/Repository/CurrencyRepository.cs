using Checkout.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Db.Repository
{
    public interface ICurrencyRepository : ICheckoutRepository<Currency>
    {
    }
    public class CurrencyRepository : CheckoutRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(CheckoutDbContext dbContext) : base(dbContext)
        {

        }
    }
}
