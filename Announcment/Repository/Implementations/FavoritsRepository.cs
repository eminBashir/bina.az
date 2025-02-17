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
    public class FavoritsRepository : GenericRepository<Favorits>, IFavoritsRepository
    {
        public FavoritsRepository(AppDbContext context) : base(context)
        {

        }
    }
}
