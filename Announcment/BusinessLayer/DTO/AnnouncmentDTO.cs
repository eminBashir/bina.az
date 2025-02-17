using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class AnnouncmentDTO
    {
        public int CategoriesID { get; set; }
        public int AnnouncmentTypeID { get; set; }
        public int RoomCount { get; set; }
        public double Area { get; set; }
        public int Floor { get; set; }
        public int TotalFloor { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool Repair { get; set; }
        public bool Excerpt { get; set; }
        public bool Ipoteka { get; set; }
        public int RegionID { get; set; }
        public int SettlementID { get; set; }
        public string Address { get; set; }
        public IFormFile AnnouncmentImage { get; set; }

    }
}
