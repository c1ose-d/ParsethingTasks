using System;
using System.Collections.Generic;

namespace ParsethingTasks;

public partial class Position
{
    public int PositionId { get; set; }

    public string? Position1 { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
