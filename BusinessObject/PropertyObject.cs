using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class PropertyObject
    {
        public int PropertyId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public double Area { get; set; }
        public decimal Price { get; set; }
        public string Available { get; set; }
    }
}
