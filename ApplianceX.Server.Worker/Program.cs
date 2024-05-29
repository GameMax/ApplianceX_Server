using System;
using ApplianceX.Server.Api.Service;
using ApplianceX.Server.Database;
using ApplianceX.Server.Parsers;
using ApplianceX.Server.UseCase;
using ApplianceX.Server.Worker.Rozetka;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(
        config =>
        {
            config.AddJsonFile("appsettings.json")
                .Build();
        })
    .ConfigureServices(
        (hostContext, services) =>
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            services.AddDbContext<PostgreSqlContext>(opt => opt.UseNpgsql
            (
               hostContext.Configuration.GetConnectionString("PostgreSqlConnection")
            ));

            services.AddHttpClient<IBaseParser, BaseParser>();
            
            services.AddSingleton<IRozetkaParser, RozetkaParser>();
            
            
            services.AddHostedService<RozetkaProductService>();
    

            services.AddSingleton<IUseCaseContainer>(
                sp => Factory.Create(
                    sp.GetRequiredService<ILoggerFactory>(),
                    sp.GetRequiredService<IRozetkaParser>()
                )
            );
        })
    .Build();

host.Run();