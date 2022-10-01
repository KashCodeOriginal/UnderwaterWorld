using System;
using Zenject;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;

public class FoodFabric : IFoodFabric
{
    public event Action OnInstancesListChanged;

    public IReadOnlyList<GameObject> Instances
    {
        get => _instances;
    }

    private readonly DiContainer _container;
    private readonly ISceneInfoService _sceneInfoService;
    private readonly IAssetsAddressableService _assetsAddressableService;

    private List<GameObject> _instances;

    public FoodFabric(DiContainer container, ISceneInfoService sceneInfoService, IAssetsAddressableService assetsAddressableService)
    {
        _container = container;
        _sceneInfoService = sceneInfoService;
        _assetsAddressableService = assetsAddressableService;
    }

    public GameObject CreateObject(Vector3 position, params FoodDecorator[] decorators)
    {
        FoodConfig foodConfig =
            _assetsAddressableService.GetAsset<FoodConfig>(AssetsAdresses.BASE_FOOD_CONFIG_ADDRESS);

        FoodStats foodStats = GetUnitStatsFromConfig(foodConfig);

        GameObject foodInstance = SpawnGameobject(foodConfig);
        
        DecorateStats(ref foodStats, decorators);

        return new GameObject();
    }

    public void DestroyInstance()
    {
        throw new NotImplementedException();
    }

    public void DestroyAllInstances()
    {
        throw new NotImplementedException();
    }

    private FoodStats GetUnitStatsFromConfig(FoodConfig foodConfig)
    {
        return new FoodStats(
            foodConfig.Mesh,
            foodConfig.Color,
            foodConfig.Size,
            foodConfig.RecoveryValue
        );
    }

    private GameObject SpawnGameobject(FoodConfig foodConfig)
    {
        if (foodConfig.Prefab == null)
        {
            throw new System.NullReferenceException($"There is no prefab on {foodConfig}");
        }

        GameObject foodInstance = _container.InstantiatePrefab(foodConfig.Prefab);

        return foodInstance;
    }

    private void DecorateStats(ref FoodStats foodStats, params FoodDecorator[] decorators)
    {
        for (int i = 0; i < decorators.Length; i++)
        {
            decorators[i].Decorate(ref foodStats);
        }
    }

    private void SetUp(GameObject foodInstance, Vector3 position)
    {
        foodInstance.transform.position = position;
        
        
    }
}
