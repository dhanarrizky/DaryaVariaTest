using System;
using System.Collections.Generic;

namespace DaryaVariaTest.Models;

public partial class AccountDetail
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public string? AccountType { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Account Account { get; set; } = null!;
}
