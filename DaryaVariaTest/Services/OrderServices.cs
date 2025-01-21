using DaryaVariaTest.Helper;
using DaryaVariaTest.IRepositories;
using DaryaVariaTest.Models;
using DaryaVariaTest.Models.Api.Request;
using DaryaVariaTest.Models.Api.Response;

namespace DaryaVariaTest.Services;

public class OrderServices {
    private readonly IOrderRepository _repo;
    public OrderServices(IOrderRepository orderRepository){
        _repo = orderRepository;
    }

    public List<Transaction> GetAllTransaction() {
        return _repo.GetAllTransaction();
    }

    public BaseApiResponse<string> CreateNewTransaaction(TransactionApiRequest req) {
        var id = _repo.CreateNewMainTransaction(
                    ObjConverter.ConvertTo<Transaction>(req.TransactionInfo));

        if (id == 0) {
            throw new InvalidDataException("Internal Server error");
        }

        var result = _repo.CreateNewProductsTransaction(
                    req.Products.Select(p => 
                        new ProductsTransaction {
                            TransactionId = p.TransactionId,
                            ProductId = p.ProductId,
                            Quantity = p.Quantity,
                            Price = p.Price,
                            TotalAmount = p.TotalAmount,
                        }
                    ).ToList()
                    , id);
                    
        return result ? new SuccessApiResponse<string>("seccess") :
                        new ErrorApiResponse<string>("Error");
    }

    public BaseApiResponse<Transaction> GetDetailTransaction(int trxId)
    {
        try {
            var transaction = _repo.GetDetailTransaction(trxId);
            
            if (transaction != null) {
                return new SuccessApiResponse<Transaction>(transaction);
            } else {
                return new ErrorApiResponse<Transaction>("Transaction not found", 404);
            }
        } catch (Exception ex) {
            return new ErrorApiResponse<Transaction>($"An error occurred: {ex.Message}", 500);
        }
    }


    // public ExecutionIdResponse GetTransactionExecutionId() {
    //     return ;
    // }
}