using System;
using System.Collections.Generic;

namespace ParsethingTasks;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? Initials { get; set; }

    public string? Avatar { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public int? PositionId { get; set; }

    public virtual Position? Position { get; set; }
}
