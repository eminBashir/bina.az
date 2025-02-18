using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entity
{
    public class Announcment : BaseEntity
    {
        public string Address { get; set; }
        public decimal Price { get; set; }
        public int Floor { get; set; }
        public int TotalFloor { get; set; }
        public int RoomCount { get; set; }
        public double Area { get; set; }
        public string? Description { get; set; }
        public bool Excerpt { get; set; }
        public int CityID { get; set; }
        public int RegionID { get; set; }
        public int SettlementID { get; set; }
        public int AnnounceTypeID { get; set; }
        public int StatusID { get; set; }
        public int CategoryID { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public User User { get; set; }
        public ICollection<AnnouncmentImages> AnnoucmentImages { get; set; }
    }
}
