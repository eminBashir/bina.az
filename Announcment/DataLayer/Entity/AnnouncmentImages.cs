using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entity
{
    public class AnnouncmentImages : BaseEntity
    {
        public int AnnouncmentId { get; set; }
        public string Imagepath { get; set; }
        public Announcment Announcment { get; set; }
    }
}
