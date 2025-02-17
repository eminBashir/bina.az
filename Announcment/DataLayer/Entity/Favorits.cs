using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entity
{
    public class Favorits : BaseEntity
    {
        public int UserID { get; set; }
        public int AnnouncmentID { get; set; }
        public User User { get; set; }
        public Announcment Announcment { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
