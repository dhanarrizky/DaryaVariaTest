namespace DaryaVariaTest.Models;

public partial class PaymentRequest
{
    public int Id { get; set; }

    public int TransactionId { get; set; }

    public string FromBankNumber { get; set; } = null!;

    public string ToBankNumber { get; set; } = null!;

    public DateTime PaymentDate { get; set; }

    public decimal PaymentAmount { get; set; }

    public string? PaymentMethod { get; set; }

    public string? Note { get; set; }
}
