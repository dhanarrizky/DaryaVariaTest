using DaryaVariaTest.Models;

namespace DaryaVariaTest.IRepositories;

public interface IProductRepository {
    public List<Product> GetAllProduct();
}