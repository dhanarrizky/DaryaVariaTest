using DaryaVariaTest.IRepositories;
using DaryaVariaTest.Models;

namespace DaryaVariaTest.Repositories;

public class OrderRepository : IOrderRepository {
    private readonly DaryaVariaApp2Context _context;
    public OrderRepository(DaryaVariaApp2Context context){
        _context = context;
    }

    public List<Transaction> GetAllTransaction() {
        var query = from Transaction in _context.Transactions
                    select Transaction;

        return query.ToList();
    }
}