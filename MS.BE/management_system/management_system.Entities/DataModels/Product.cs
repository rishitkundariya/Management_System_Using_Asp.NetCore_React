using System;
using System.Collections.Generic;

namespace management_system.Entities.DataModels;

public partial class Product
{
    public long ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public long StockAvailability { get; set; }

    public double Price { get; set; }

    public string? RackNumber { get; set; }

    public long GstTaxSlab { get; set; }
}
