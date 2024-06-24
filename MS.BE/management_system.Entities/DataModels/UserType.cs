using System;
using System.Collections.Generic;

namespace management_system.Entities.DataModels;

public partial class UserType
{
    public long UserTypeId { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
