using Checkout.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Db.Repository
{
    public interface ICardDetailsRepository : ICheckoutRepository<CardDetails>
    {
    }
    public class CardDetailsRepository : CheckoutRepository<CardDetails>, ICardDetailsRepository
    {
        public CardDetailsRepository(CheckoutDbContext dbContext) : base(dbContext)
        {

        }
    }
}
