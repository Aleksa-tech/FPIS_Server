using FPIS.DAL;
using FPIS.DAL.Repository;
using FPIS.Entities;
using FPIS.ServiceEntities;
using FPIS.ServiceEntities.AccountBalanceService;
using FPIS.ServiceEntities.ClientService;
using FPIS.Services.AccountBalanceService;
using FPIS.Services.AccountBalanceService.Decorator;
using FPIS.Services.AccountService;
using FPIS.Services.ClientService;
using FPIS.Services.ClientService.Decorator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.IoC
{
    public static class ServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DbSettings>(configuration.GetSection("DbSettings"));
            services.AddSingleton<ILogger>(Log.Logger);

            #region Client service
            services.AddTransient<IValidationService<Klijent>, ClientValidation>();
            services.AddTransient<IReadService<Klijent>, ClientRead>();
            services.AddTransient<IDeleteService<Klijent>, ClientDelete>();

            services.AddTransient<IInsertService<Klijent>, ClientInsert>();
            services.Decorate<IInsertService<Klijent>, ClientInsertValidation>();

            services.AddTransient<IUpdateService<Klijent>, ClientUpdate>();
            services.Decorate<IUpdateService<Klijent>, ClientUpdateValidation>();

            services.AddTransient<IClientFacade, ClientServiceFacade>();
            #endregion

            #region Account balance service
            services.AddTransient<IValidationService<Stanje>, AccountBalanceValidation>();
            services.AddTransient<IReadService<Stanje>, AccountBalanceRead>();
            services.AddTransient<IGetBalancesByAccountService, GetBalancesByAccountService>();
            services.AddTransient<IDeleteService<Stanje>, AccountBalanceDelete>();

            services.AddTransient<IInsertService<Stanje>, AccountBalanceInsert>();
            services.Decorate<IInsertService<Stanje>, AccountBalanceInsertValidation>();

            services.AddTransient<IUpdateService<Stanje>, AccountBalanceUpdate>();
            services.Decorate<IUpdateService<Stanje>, AccountBalanceUpdateValidation>();

            services.AddTransient<IAccountBalanceFacade, AccountBalanceServiceFacade>();
            #endregion

            #region Account service
            services.AddTransient<IReadService<Racun>, AccountRead>();
            services.AddTransient<IGetAccountByIdAndTypeService, GetAccountByIdAndTypeService>();
            services.AddTransient<IAccountFacade, AccountServiceFacade>();
            #endregion

            RegisterRepository(services);
        }

        private static void RegisterRepository(IServiceCollection services)
        {
            services.Scan(scan => scan.FromAssemblyOf<DALScrutorRegistration>()
                                      .AddClasses(classes => classes.AssignableTo<BaseSqlRepository>())
                                      .AsFirstInheritedInterface()
                                      .WithScopedLifetime());
        }
    }
}
