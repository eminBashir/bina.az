using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.UoW
{
    public interface IUnitOfWork
    {
        IAnnouncmentRepository announcmentRepository { get; }
        IAnnouncmentImagesRepository announcmentImagesRepository { get; }
        IAnnouncmentStatusRepository announcmentStatusRepository { get; }
        IAnnouncmentTypeRepository announcmentTypeRepository { get; }
        ICategoriesRepository categoriesRepository { get; }
        ICityRepository cityRepository { get; }
        IFavoritsRepository favoritsRepository { get; }
        IPaymentRepository paymentRepository { get; }
        IRegionRepository regionRepository { get; }
        IRoleRepository roleRepository { get; }
        ISettlementRepository settlementRepository { get; }
        IStatusRepository statusRepository { get; }
        IUserRepository userRepository { get; }
        Task<int> Submit();
    }
}
