using DaryaVariaTest.Models;

namespace DaryaVariaTest.IRepositories;

public interface IOrderRepository {

    public List<Transaction> GetAllTransaction();
    public bool CreateInformationOfPayment(InformationOfPayment iop);
    public int CreateNewMainTransaction(Transaction trx);
    public bool CreateNewProductsTransaction(List<ProductsTransaction> products, int transactionId);
    public Transaction GetDetailTransaction(int trxId);
    public bool UpdateTransaction(Transaction trx);
}