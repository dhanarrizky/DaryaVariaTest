using DaryaVariaTest.Models;

namespace DaryaVariaTest.IRepositories;

public interface IOrderRepository {

    public List<Transaction> GetAllTransaction();
    public int CreateNewMainTransaction(Transaction trx);
    public bool CreateNewProductsTransaction(List<ProductsTransaction> products, int transactionId);
    public Transaction GetDetailTransaction(int trxId);
}