using DataLayer.Context;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IFavoritsRepository favoritsRepository { get; private set; }
        public IPaymentRepository paymentRepository { get; private set; }
        public IRegionRepository regionRepository { get; private set; }
        public IRoleRepository roleRepository { get; private set; }
        public ISettlementRepository settlementRepository { get; private set; }
        public IStatusRepository statusRepository { get; private set; }
        public IUserRepository userRepository { get; private set; }
        public ICityRepository cityRepository { get; private set; }
        public ICategoriesRepository categoriesRepository { get; private set; }
        public IAnnouncmentTypeRepository announcmentTypeRepository { get; private set; }
        public IAnnouncmentStatusRepository announcmentStatusRepository { get; private set; }
        public IAnnouncmentImagesRepository announcmentImagesRepository { get; private set; }
        public IAnnouncmentRepository announcmentRepository { get; private set; }
        
        public UnitOfWork(AppDbContext context, IAnnouncmentRepository announcmentRepository,
                   IAnnouncmentImagesRepository announcmentImagesRepository, IAnnouncmentStatusRepository announcmentStatusRepository,
                   IAnnouncmentTypeRepository announcmentTypeRepository, ICategoriesRepository categoriesRepository, ICityRepository cityRepository,
                   IFavoritsRepository favoritsRepository, IPaymentRepository paymentRepository, IRegionRepository regionRepository,
                   IRoleRepository roleRepository, ISettlementRepository settlementRepository, IStatusRepository statusRepository,
                   IUserRepository userRepository)
        {
            _context = context;
            this.announcmentRepository = announcmentRepository;
            this.announcmentImagesRepository = announcmentImagesRepository;
            this.announcmentStatusRepository = announcmentStatusRepository;
            this.announcmentTypeRepository = announcmentTypeRepository;
            this.categoriesRepository = categoriesRepository;
            this.cityRepository = cityRepository;
            this.favoritsRepository = favoritsRepository;
            this.paymentRepository = paymentRepository;
            this.regionRepository = regionRepository;
            this.roleRepository = roleRepository;
            this.settlementRepository = settlementRepository;
            this.statusRepository = statusRepository;
            this.userRepository = userRepository;
        }
        public async Task<int> Submit()
        {
            using (var tr = _context.Database.BeginTransaction())
            {
                try
                {
                    return await _context.SaveChangesAsync();
                    await tr.CommitAsync();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw new Exception(ex.Message, ex);
                }
            }
        }

    }
}
