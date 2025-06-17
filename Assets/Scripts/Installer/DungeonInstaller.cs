using ProceduralDungeon.Infrastructure;
using ProceduralDungeon.UseCases;
using Zenject;

public class DungeonInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<DungeonGenerator>().AsSingle();
        Container.Bind<GenerateDungeonUseCase>().AsSingle();
    }
}
