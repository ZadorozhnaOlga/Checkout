using Checkout.Db.Models;

namespace Checkout.Gateway.Api.Interfaces
{
    public interface ITransactionService
    {
        Task<Transaction> SaveTransaction(Transaction transaction);

        Task<IEnumerable<Transaction>> GetAll();

        Task<Transaction> GetById(int transactionId);

        Task<Transaction> UpdateTransaction(Transaction transaction);

        Task<bool> DeleteTransaction(int transactionId);
    }
}
