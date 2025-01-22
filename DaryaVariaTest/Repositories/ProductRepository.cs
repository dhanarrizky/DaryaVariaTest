using DaryaVariaTest.IRepositories;
using DaryaVariaTest.Models;
using Microsoft.EntityFrameworkCore;

namespace DaryaVariaTest.Repositories;

public class ProductRepository : IProductRepository {
    private readonly DaryaVariaAppContext _context;
    public ProductRepository(DaryaVariaAppContext context){
        _context = context;
    }

    public List<Product> GetAllProduct() {
        return _context.Products.ToList();
    }
}