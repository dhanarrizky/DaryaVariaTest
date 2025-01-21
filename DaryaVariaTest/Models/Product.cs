using System;
using System.Collections.Generic;

namespace DaryaVariaTest.Models;

public partial class Product
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<ProductsTransaction> ProductsTransactions { get; set; } = new List<ProductsTransaction>();
}
