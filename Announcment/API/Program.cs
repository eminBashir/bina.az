using BusinessLayer;
using BusinessLayer.Config;
using DataLayer.Context;
using DataLayer.Entity;
using DataLayer.Extensions;
using DomainLayer.Config;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Repository.Config;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;
            var configuration = builder.Configuration;

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\""
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        Array.Empty<string>()
    }
});
            });

            services.AddServices(configuration);
            services.AddDomainLayer();
            services.AddRepositoryConfig();
            services.AddBusinessLayer(configuration);

            builder.Services.AddIdentity<User, Role>(options =>
            {
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider; //Burada DefaultEmailProvider ASP.NET Core Identity t?r?find?n
                                                                                                   //t?yin olunan standart e-poçt t?sdiqi token provayderidir.
                                                                                                   //?stifad?çi qeydiyyatdan keçdikd?n sonra sistem avtomatik olaraq
                                                                                                   //bu tokeni yarad?r v? e-poçt vasit?sil? istifad?çiy? gönd?rir.
                                                                                                   //?stifad?çi e-poçtunu t?sdiql?dikd?n sonra hesab aktivl??ir.

                options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultProvider;  //DefaultProvider burada ?ifr? s?f?rlama tokeni üçün standart
                                                                                           //t?minatç?d?r. ?stifad?çi “?ifr?mi unutdum” funksiyas?ndan
                                                                                           //istifad? etdikd?, bu token e-poçt vasit?sil? gönd?rilir v?
                                                                                           //istifad?çi tokeni daxil ed?r?k yeni ?ifr? t?yin ed? bilir.

                options.Tokens.AuthenticatorTokenProvider = TokenOptions.DefaultAuthenticatorProvider; //DefaultAuthenticatorProvider iki faktorlu do?rulama
                                                                                                       //tokeni yarad?r. Bu token, istifad?çi giri? etm?k
                                                                                                       //ist?dikd? do?rulama t?tbiqi il? yarad?lan unikal
                                                                                                       //bir kod vasit?sil? t?sdiql?nir. Bu, hesab?n
                                                                                                       //t?hlük?sizliyini art?rmaq üçün ?lav? bir add?md?r.

            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            services.AddMvc().AddNewtonsoftJson(options =>
            { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; });

            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

