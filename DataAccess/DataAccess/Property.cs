using System;
using System.Collections.Generic;

namespace DataAccess.DataAccess;

public partial class Property
{
    public int PropertyId { get; set; }

    public string? Name { get; set; }

    public string? Location { get; set; }

    public double? Area { get; set; }

    public decimal? Price { get; set; }

    public string? Contact { get; set; }

    public string? Available { get; set; }

    public virtual ICollection<Feature> Features { get; } = new List<Feature>();

    public virtual ICollection<PriceHistory> PriceHistories { get; } = new List<PriceHistory>();

    public virtual ICollection<PropertyOwner> PropertyOwners { get; } = new List<PropertyOwner>();
}
