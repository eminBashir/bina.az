using Microsoft.Extensions.DependencyInjection;
using Repository.Interfaces;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Config
{
    public static class RepositoryConfig
    {
        public static void AddRepositoryConfig(this IServiceCollection services)
        {
            services.AddScoped<IAnnouncmentRepository, AnnouncmentRepository>();
            services.AddScoped<IAnnouncmentImagesRepository, AnnouncmentImagesRepository>();
            services.AddScoped<IAnnouncmentStatusRepository, AnnouncmentStatusRepository>();
            services.AddScoped<IAnnouncmentTypeRepository, AnnouncmentTypeRepository>();
            services.AddScoped<ICategoriesRepository,CategoriesRepository>();
            services.AddScoped<ICityRepository,CityRepository>();
            services.AddScoped<IFavoritsRepository,FavoritsRepository>();
            services.AddScoped<IPaymentRepository,PaymentRepository>();
            services.AddScoped<IRegionRepository,RegionRepository>();
            services.AddScoped<IRoleRepository,RoleRepository>();
            services.AddScoped<ISettlementRepository,SettlementRepository>();
            services.AddScoped<IStatusRepository,StatusRepository>();
            services.AddScoped<IUserRepository,UserRepository>();
        }
    }
}
