using ApplianceX.Server.Parsers;
using Microsoft.Extensions.Logging;

namespace ApplianceX.Server.UseCase;

public static class Factory
{
    public static UseCaseContainer Create(ILoggerFactory loggerFactory, IRozetkaParser rozetkaParser)
    {
        return new UseCaseContainer(new RozetkaUseCase(loggerFactory.CreateLogger<RozetkaUseCase>(), rozetkaParser));
    }
}