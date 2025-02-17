using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entity
{
    public class Region : BaseEntity
    {
        public string Name { get; set; }
        public int CityId { get; set; }
        public ICollection<Settlement> Settlements { get; set;}
    }
}
