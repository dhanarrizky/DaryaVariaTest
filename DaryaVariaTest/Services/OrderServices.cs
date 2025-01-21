using DaryaVariaTest.IRepositories;
using DaryaVariaTest.Models;

namespace DaryaVariaTest.Services;

public class OrderServices {
    private readonly IOrderRepository _repo;
    public OrderServices(IOrderRepository orderRepository){
        _repo = orderRepository;
    }

    public List<Transaction> GetAllTransaction() {
        return _repo.GetAllTransaction();
        // try {
        // } catch (Exception e) {
        //     Console.WriteLine($"Exception : {e}");
        //     return new List<Transaction>();
        // }
    }
}