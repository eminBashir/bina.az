using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entity
{
    public class Payment : BaseEntity
    {
        public int StatusID { get; set; }
        public int AnnouncmentID { get; set; }
        public DateTime ExpDate { get; set; }
    }
}
