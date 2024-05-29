namespace ApplianceX.Server.UseCase;

public class UseCaseContainer : IUseCaseContainer
{
    public IRozetkaUseCase RozetkaUseCase { get; }


    public UseCaseContainer(IRozetkaUseCase rozetkaUseCase)
    {
        RozetkaUseCase = rozetkaUseCase;
    }
}