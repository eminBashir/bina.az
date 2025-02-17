using DataLayer.Context;
using DataLayer.Entity;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class AnnouncmentImagesRepository : GenericRepository<AnnouncmentImages>, IAnnouncmentImagesRepository
    {
        public AnnouncmentImagesRepository(AppDbContext context) : base(context)
        {

        }
    }
}
