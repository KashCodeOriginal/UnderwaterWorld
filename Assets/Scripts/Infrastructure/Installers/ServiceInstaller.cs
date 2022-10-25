using System;
using Zenject;
using UnityEngine;

public class ServiceInstaller : MonoInstaller
{
    [SerializeField] private GameSettings _gameSettings;
    
    public override void InstallBindings()
    {
        BindWatchers();
        BindFoodFactory();
        BindUIFactory();
        BindAbstractFactory();
        BindEnemyFactory();
        BindAssetsAddressable();
        BindFoodRelationService();
        BindGameSettings();
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

    private void BindEnemyFactory()
    {
        Container.BindInterfacesTo<UnitFactory>().AsSingle();
    }
    
    private void BindFoodRelationService()
    {
        Container.BindInterfacesTo<FoodRelationService>().AsSingle();
    }
    
    private void BindGameSettings()
    {
        Container.Bind<GameSettings>().FromInstance(_gameSettings).AsSingle();
    }

    private void BindWatchers()
    {
        Container.BindInterfacesTo<UnitsUnitsDeathWatch>().AsSingle();

        Container.BindInterfacesTo<FoodsFoodEatWatch>().AsSingle();
    }
    
}
