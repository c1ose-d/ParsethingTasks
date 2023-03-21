using System;
using System.Collections.Generic;

namespace ParsethingTasks;

public partial class Organization
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string PostalAddress { get; set; } = null!;

    public virtual ICollection<Procurement> Procurements { get; } = new List<Procurement>();
}
