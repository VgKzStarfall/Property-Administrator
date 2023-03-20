using System;
using System.Collections.Generic;

namespace DataAccess.DataAccess;

public partial class PriceHistory
{
    public int PriceId { get; set; }

    public int? PropertyId { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? Date { get; set; }

    public virtual Property? Property { get; set; }
}
