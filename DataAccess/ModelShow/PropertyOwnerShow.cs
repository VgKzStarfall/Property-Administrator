using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ModelShow
{
    public class PropertyOwnerShow
    {
        public int OwnId { get; set; }
        public string LandlordName { get; set; }
        public DateTime OwnStartDate { get; set; }
        public DateTime? OwnEndDate { get; set; }
    }
}
