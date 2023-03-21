﻿using System;
using System.Collections.Generic;

namespace ParsethingTasks;

public partial class Method
{
    public int Id { get; set; }

    public string Text { get; set; } = null!;

    public virtual ICollection<Procurement> Procurements { get; } = new List<Procurement>();
}
