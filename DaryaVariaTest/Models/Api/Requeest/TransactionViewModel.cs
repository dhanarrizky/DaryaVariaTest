using System;
using System.Collections.Generic;

namespace DaryaVariaTest.Models;

public partial class TransactionViewModel
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public string? AccountType { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public string? Note { get; set; }

    public decimal Discount { get; set; }

    public decimal Tax { get; set; }

    public decimal TotalAmount { get; set; }

    public string? Status { get; set; }
}
