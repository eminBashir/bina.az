﻿using DataLayer.Context;
using DataLayer.Entity;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class AnnouncmentStatusRepository : GenericRepository<AnnouncmentStatus>, IAnnouncmentStatusRepository
    {
        public AnnouncmentStatusRepository(AppDbContext context) : base(context)
        {

        }
    }
}
