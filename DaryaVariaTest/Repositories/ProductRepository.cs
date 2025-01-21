using DaryaVariaTest.IRepositories;
using DaryaVariaTest.Models;
using Microsoft.EntityFrameworkCore;

namespace DaryaVariaTest.Repositories;

public class ProductRepository : IProductRepository {
    private readonly DaryaVariaApp2Context _context;
    public ProductRepository(DaryaVariaApp2Context context){
        _context = context;
    }

    public List<Product> GetAllProduct() {
        return _context.Products.ToList();
    }
}