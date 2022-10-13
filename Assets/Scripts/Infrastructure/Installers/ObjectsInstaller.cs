using Zenject;

public class ObjectsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindStatsService();
    }

    private void BindStatsService()
    {
        Container.BindInterfacesAndSelfTo<StatsService>().AsTransient();
    }
}
