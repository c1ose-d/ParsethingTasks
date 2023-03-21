﻿using System;
using System.Collections.Generic;

namespace ParsethingTasks;

public partial class Procurement
{
    public int Id { get; set; }

    public string RequestUri { get; set; } = null!;

    public string Number { get; set; } = null!;

    public int? LawId { get; set; }

    public int? MethodId { get; set; }

    public int? PlatformId { get; set; }

    public int? OrganizationId { get; set; }

    public string Object { get; set; } = null!;

    public string Location { get; set; } = null!;

    public DateTime? StartDate { get; set; }

    public DateTime? Deadline { get; set; }

    public int TimeZoneId { get; set; }

    public decimal InitialPrice { get; set; }

    public string? Securing { get; set; }

    public string? Enforcement { get; set; }

    public string? Warranty { get; set; }

    public int? RegionId { get; set; }

    public string? NameOfOrganizationContract { get; set; }

    public string? AddressOfOrganizationContract { get; set; }

    public string? ContactPerson { get; set; }

    public string? ContactPhone { get; set; }

    public string? DeliveryDetails { get; set; }

    public string? PeriodAndType { get; set; }

    public string? DeliveryTime { get; set; }

    public string? AcceptancePeriod { get; set; }

    public string? TermOfContract { get; set; }

    public bool? Indefinitely { get; set; }

    public string? OrBool { get; set; }

    public string? TimeAndOrder { get; set; }

    public int? RepresentativeOrAdminId { get; set; }

    public int? CommissioningWorksId { get; set; }

    public int? Places { get; set; }

    public string? FinesAndPennies { get; set; }

    public virtual Law? Law { get; set; }

    public virtual Method? Method { get; set; }

    public virtual Organization? Organization { get; set; }

    public virtual Platform? Platform { get; set; }

    public virtual TimeZone TimeZone { get; set; } = null!;
}
