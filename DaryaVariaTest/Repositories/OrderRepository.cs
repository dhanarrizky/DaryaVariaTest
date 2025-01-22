using DaryaVariaTest.IRepositories;
using DaryaVariaTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace DaryaVariaTest.Repositories;

public class OrderRepository : IOrderRepository {
    private readonly DaryaVariaApp2Context _context;
    public OrderRepository(DaryaVariaApp2Context context){
        _context = context;
    }

    public List<Transaction> GetAllTransactionWithDetailProductTrx() {
        return _context.Transactions.Include(t => t.ProductsTransactions).ToList();
    }

    public List<Transaction> GetAllTransaction() {
        return _context.Transactions.Include(t => t.Account).ToList();
    }

    public bool CreateInformationOfPayment(InformationOfPayment iop) {
        _context.InformationOfPayments.Add(iop);
        var res = _context.SaveChanges();
        return res > 0;
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
                .Where(t => t.Id == trxId).FirstOrDefault() ?? throw new ArgumentException("Transaction With {trxId} TransactionId Not Found");
    }

    public bool UpdateTransaction(Transaction trx) {
        var obj = _context.Transactions.FirstOrDefault(t => t.Id == trx.Id);

        if (obj == null) return false;
        obj.Id = trx.Id;
        obj.AccountId = trx.AccountId;
        obj.AccountType = trx.AccountType;
        obj.OrderDate = trx.OrderDate;
        obj.DeliveryDate = trx.DeliveryDate;
        obj.Note = trx.Note;
        obj.Discount = trx.Discount;
        obj.Tax = trx.Tax;
        obj.TotalAmount = trx.TotalAmount;
        obj.Status = trx.Status;

        _context.SaveChanges();
        return true;
    }

}