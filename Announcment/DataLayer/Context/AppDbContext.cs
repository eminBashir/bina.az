using DataLayer.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Context
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Announcment> Announcments { get; set; }
        public DbSet<AnnouncmentImages> AnnouncmentsImages { get; set; }
        public DbSet<AnnouncmentStatus> AnnouncmentsStatus { get; set; }
        public DbSet<AnnouncmentType> AnnouncmentsType { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Favorits> Favorits { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Settlement> Settlements { get; set; }
        public DbSet<Status> Statuses { get; set; }

    }
}
