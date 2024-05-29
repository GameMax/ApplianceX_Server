using System;
using System.Threading;
using System.Threading.Tasks;
using ApplianceX.Server.Database;
using ApplianceX.Server.UseCase;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ApplianceX.Server.Worker.Rozetka;

public class RozetkaProductService : BackgroundService
{
    private readonly ILogger<RozetkaProductService> _logger;
    private readonly IUseCaseContainer _useCase;

    private readonly IServiceProvider _serviceProvider;


    public RozetkaProductService(ILogger<RozetkaProductService> logger, IUseCaseContainer useCase, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _useCase = useCase;
        _serviceProvider = serviceProvider;
    }


    async protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // while (!stoppingToken.IsCancellationRequested)
        // {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<PostgreSqlContext>();

            var brandRepo = context.Db.BrandRepository;
            var categoryRepo = context.Db.CategoryRepository;
            var productRepo = context.Db.ProductRepository;
            var productStatisticRepo = context.Db.ProductStatisticRepository;
            var sellerRepo = context.Db.SellerRepository;
            var sellerStatisticRepo = context.Db.SellerStatisticRepository;

            _logger.LogInformation("Parsing process is starting...");
        
            await _useCase.RozetkaUseCase.ParseProducts(productRepo, productStatisticRepo, brandRepo, categoryRepo, sellerRepo, sellerStatisticRepo, stoppingToken);

            _logger.LogInformation("Parsing process has been finished!");

            // await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
        // }
    }
}