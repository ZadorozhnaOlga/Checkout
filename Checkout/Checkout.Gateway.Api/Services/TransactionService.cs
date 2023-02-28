using Checkout.Db.Models;
using Checkout.Db.Repository;
using Checkout.Gateway.Api.Interfaces;

namespace Checkout.Gateway.Api.Services
{
    public class TransactionService : ITransactionService
    {
        public ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository) 
        {
            _transactionRepository = transactionRepository;
        }
        public Task<bool> DeleteTransaction(int transactionId)
        {
           return _transactionRepository.Delete(transactionId);
        }

        public Task<IEnumerable<Transaction>> GetAll()
        {
            return _transactionRepository.GetAll();
        }

        public Task<Transaction> GetById(int transactionId)
        {
            return _transactionRepository.GetById(transactionId);
        }

        public Task<Transaction> SaveTransaction(Transaction transaction)
        {
            return _transactionRepository.Add(transaction);
        }

        public Task<Transaction> UpdateTransaction(Transaction transaction)
        {
            return _transactionRepository.Update(transaction);
        }
    }
}
