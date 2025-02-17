using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entity
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Region> Regions { get; set; }
    }
}
