using DaryaVariaTest.IRepositories;
using DaryaVariaTest.Models;
using Microsoft.EntityFrameworkCore;

namespace DaryaVariaTest.Repositories;

public class OrderRepository : IOrderRepository {
    private readonly DaryaVariaApp2Context _context;
    public OrderRepository(DaryaVariaApp2Context context){
        _context = context;
    }

    public List<Transaction> GetAllTransaction() {
        return _context.Transactions.Include(t => t.Account).ToList();
    }

    public int CreateNewMainTransaction(Transaction trx) {
        _context.Transactions.Add(trx);
        var res = _context.SaveChanges();
        if(res > 0) {
            return trx.Id;
        }

        return 0;
    }

    public bool CreateNewProductsTransaction(List<ProductsTransaction> products, int transactionId) {
        foreach(var product in products) {
            product.TransactionId = transactionId;
            _context.ProductsTransactions.Add(product);
        }

        var res = _context.SaveChanges();
        return res > 0;
    }

    public Transaction GetDetailTransaction(int trxId) {
        return _context.Transactions
                .Include(t => t.Account)
                .Include(t => t.InformationOfPayments)
                .Include(t => t.ProductsTransactions)
                .ThenInclude(pt => pt.Product)
                .Where(t => t.Id == trxId).FirstOrDefault() ?? throw new ArgumentException("Transaction With {trxId} TransactionId Not Found");
    }
}