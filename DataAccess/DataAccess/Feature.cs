using System;
using System.Collections.Generic;

namespace DataAccess.DataAccess;

public partial class Feature
{
    public int FeatureId { get; set; }

    public int? PropertyId { get; set; }

    public string? FeatureDescription { get; set; }

    public virtual Property? Property { get; set; }
}
