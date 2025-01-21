using DaryaVariaTest.IRepositories;
using DaryaVariaTest.Models;
using DaryaVariaTest.Models.Api.Response;

namespace DaryaVariaTest.Services;

public class ProductServices {
    private readonly IProductRepository _repo;
    public ProductServices(IProductRepository orderRepository){
        _repo = orderRepository;
    }

    public List<Product> GetAllProducts() {
        return _repo.GetAllProduct();
    }
}