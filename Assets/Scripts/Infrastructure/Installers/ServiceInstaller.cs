using Zenject;

public class ServiceInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindFoodFactory();
        BindUIFactory();
        BindAbstractFactory();
        BindAssetsAddressable();
    }
    
    private void BindAssetsAddressable()
    {
        Container.BindInterfacesTo<AssetsAddressable>().AsSingle();
    }

    private void BindFoodFactory()
    {
        Container.BindInterfacesTo<FoodFactory>().AsSingle();
    }

    private void BindUIFactory()
    {
        Container.BindInterfacesTo<UIFactory>().AsSingle();
    }

    private void BindAbstractFactory()
    {
        Container.BindInterfacesTo<AbstractFactory>().AsSingle();
    }
}
