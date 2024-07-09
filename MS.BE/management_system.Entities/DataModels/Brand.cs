using System;
using System.Collections.Generic;

namespace management_system.Entities.DataModels;

public partial class Brand : BaseEntity
{
    public long BrandId { get; set; }

    public string Name { get; set; } = null!;

    public string ShortName { get; set; } = null!;

}
