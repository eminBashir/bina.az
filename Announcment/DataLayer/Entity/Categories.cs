using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entity
{
    public class Categories : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Announcment> Announcments { get; set;}
    }
}
