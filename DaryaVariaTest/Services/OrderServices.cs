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

    public BaseApiResponse<string> ApproveRejectService(string role, string approveReject, int id) {
        try {
            string status = role.Equals("Admin", StringComparison.OrdinalIgnoreCase) 
                ? "Checked" 
                : (approveReject.Equals("Approval", StringComparison.OrdinalIgnoreCase) 
                    ? "Approved" 
                    : "Rejected");

            var transaction = _repo.GetDetailTransaction(id);
            transaction.Status = status;

            var result = _repo.UpdateTransaction(transaction);
            
            if (result) {
                return new SuccessApiResponse<string>("seccess");
            } else {
                return new ErrorApiResponse<string>("Transaction not found");
            }
        } catch (Exception ex) {
            return new ErrorApiResponse<string>($"An error occurred: {ex.Message}");
        }
    }

    public BaseApiResponse<string> ProcessOfPayment(PaymentRequest iop) {
        var res = _repo.GetDetailTransaction(iop.TransactionId);
        if(res == null) {
            return new ErrorApiResponse<string>("Bad Request : transaction Id not found") {
                StatusCode = 400,
            };
        }
        var result = _repo.CreateInformationOfPayment(ObjConverter.ConvertTo<InformationOfPayment>(iop));
        if(!result) {
            return new ErrorApiResponse<string>("internal server Error") {
                StatusCode = 500
            };
        }

        res.Status = "Delivery";
        _repo.UpdateTransaction(res);
        return new SuccessApiResponse<string>("Adding payment has been successfully");
    }

    public BaseApiResponse<string> CreateNewTransaaction(TransactionApiRequest req) {
        req.TransactionInfo.OrderDate = DateTime.Now;
        req.TransactionInfo.Status = "Panding";
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


    public BaseApiResponse<string> UpdateDelivaryDate(DelivaryDateRequest ddr) {
        var res = _repo.GetDetailTransaction(ddr.transactionId);
        if(res == null) {
            return new ErrorApiResponse<string>("Bad Request : transaction Id not found") {
                StatusCode = 400,
            };
        }

        res.DeliveryDate = ddr.DelivaryDate;
        res.Status = "Completed";
        var result = _repo.UpdateTransaction(res);
        if(!result) {
            return new ErrorApiResponse<string>("internal server Error") {
                StatusCode = 500
            };
        }

        return new SuccessApiResponse<string>("Update delivary date has been successfully");
    }
}