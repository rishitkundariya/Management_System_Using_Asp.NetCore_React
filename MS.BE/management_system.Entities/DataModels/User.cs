using System;
using System.Collections.Generic;

namespace management_system.Entities.DataModels;

public partial class User
{
    public long UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Number { get; set; } = null!;

    public long UserTypeId { get; set; }

    public bool IsDeleted { get; set; }

    public TimeOnly CreatedAt { get; set; }

    public virtual UserType UserType { get; set; } = null!;
}
