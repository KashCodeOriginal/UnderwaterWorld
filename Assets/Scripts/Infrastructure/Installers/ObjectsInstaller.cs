using Zenject;

public class ObjectsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindFoodRelationService();
    }

    private void BindFoodRelationService()
    {
        Container.BindInterfacesTo<FoodRelationService>().AsSingle();
    }
}
