using System;
using System.Collections.Generic;

namespace DataAccess.DataAccess;

public partial class Landlord
{
    public int LandlordId { get; set; }

    public string? Name { get; set; }

    public string? Tel { get; set; }

    public string? Location { get; set; }

    public string? CitizenId { get; set; }

    public virtual ICollection<PropertyOwner> PropertyOwners { get; } = new List<PropertyOwner>();
}
