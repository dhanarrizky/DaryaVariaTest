using DaryaVariaTest.Models;

namespace DaryaVariaTest.IRepositories;

public interface IOrderRepository {

    public List<Transaction> GetAllTransaction();
}