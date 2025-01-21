using System;
using System.Collections.Generic;

namespace DaryaVariaTest.Models;

public partial class AccountRole
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
}
