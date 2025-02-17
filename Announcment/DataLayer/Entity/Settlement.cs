using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entity
{
    public class Settlement : BaseEntity
    {
        public string Name { get; set; }
        public int RegionID { get; set; }
    }
}
