using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AutoMapper;
using TheCoreArchitecture.Common.APIUtilities;
using TheCoreArchitecture.Common.Repository;
using TheCoreArchitecture.Common.UnitOfWork;
using TheCoreArchitecture.Data.Context;
using TheCoreArchitecture.Data.Entities;
using TheCoreArchitecture.Data.IdentityEntities;
using TheCoreArchitecture.Data.InitialDataInitializer;
using TheCoreArchitecture.Domain.Business;
using TheCoreArchitecture.Domain.Dto.Base;
using TheCoreArchitecture.Domain.IBusiness;

namespace TheCoreArchitecture.Api.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ConfigureServiceExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddRegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbServices(configuration);
            services.AddSecurityServices(configuration);
            
            services.AddCustomSertvices();
            services.AddApiDocumentationServices();
            services.AddDomainSertvices();
            services.AddUnitOfWorkSertvices();
            services.AddRepositorySertvices();
            return services;
        }

        private static void AddDbServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyDbContext>(cfg =>
                {
                    cfg.UseSqlServer(configuration.GetConnectionString("MyConnectionString"))
                        .UseLazyLoadingProxies();
                }).AddIdentity<ApplicationUser, ApplicationRole>(option =>
                {
                    option.Password.RequireDigit = false;
                    option.Password.RequiredLength = 6;
                    option.Password.RequireNonAlphanumeric = false;
                    option.Password.RequireUppercase = false;
                    option.Password.RequireLowercase = false;
                })
                .AddEntityFrameworkStores<MyDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<DbContext, MyDbContext>();
            services.AddSingleton<IDataInitializer, DataInitializer>();
        }

        private static void AddSecurityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["Jwt:Issure"],
                    ValidateAudience = true,
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SigningKey"])),
                };
            });

            services.AddCors();
        }

        private static void AddApiDocumentationServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "My API First Version", Version = "v1" });

                options.DescribeAllEnumsAsStrings();
                var filePath = Path.Combine(AppContext.BaseDirectory, "TheCoreArchitecture.Api.xml");
                options.IncludeXmlComments(filePath);

                // Swagger 2.+ support
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                options.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                options.AddSecurityRequirement(security);

            });
        }

        private static void AddCustomSertvices(this IServiceCollection services)
        {
            services.AddTransient<IActionResultResponseHandler, ActionResultResponseHandler>();
            services.AddTransient<IRepositoryActionResult, RepositoryActionResult>();
            services.AddTransient<IRepositoryResult, RepositoryResult>();
        }

        private static void AddRepositorySertvices(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Country>, Repository<Country>>();
            services.AddTransient<IRepository<Area>, Repository<Area>>();
            services.AddTransient<IRepository<City>, Repository<City>>();
        }

        private static void AddUnitOfWorkSertvices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork<Country>, UnitOfWork<Country>>();
            services.AddTransient<IUnitOfWork<Area>, UnitOfWork<Area>>();
            services.AddTransient<IUnitOfWork<City>, UnitOfWork<City>>();
        }

        private static void AddDomainSertvices(this IServiceCollection services)
        {
            services.AddTransient<IBusinessBaseParameter<Country>, BusinessBaseParameter<Country>>();
            services.AddTransient<ICountryBusiness, CountryBusiness>();
            services.AddTransient<IBusinessBaseParameter<Area>, BusinessBaseParameter<Area>>();

            services.AddTransient<IBusinessBaseParameter<City>, BusinessBaseParameter<City>>();
        }
    }
}
