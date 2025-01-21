namespace DaryaVariaTest.Models.Api.Request;

public class TransactionApiRequest {
    public TransactionViewModel TransactionInfo { get; set; } = null!;
    public List<ProductsTransactionApiRequest> Products { get; set; } = new List<ProductsTransactionApiRequest>();
}