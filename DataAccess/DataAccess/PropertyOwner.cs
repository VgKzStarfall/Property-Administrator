using System;
using System.Collections.Generic;

namespace DataAccess.DataAccess;

public partial class PropertyOwner
{
    [System.ComponentModel.Browsable(false)]
    public int OwnId { get; set; }
    public int? PropertyId { get; set; }
    public int? LandlordId { get; set; }
    public DateTime? OwnStartDate { get; set; }
    public DateTime? OwnEndDate { get; set; }
    public virtual Landlord? Landlord { get; set; }
    public virtual Property? Property { get; set; }

    
    
}
