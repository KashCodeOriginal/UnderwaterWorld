using System;
using Zenject;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

public class FoodFactory : IFoodFactory
{
    private readonly DiContainer _container;

    private readonly IAssetsAddressableService _assetsAddressableService;

    private readonly IFoodEatObservable _foodEatObservable;

    private List<GameObject> _instances = new List<GameObject>();

    public FoodFactory(DiContainer container, IAssetsAddressableService assetsAddressableService, IFoodEatObservable foodEatObservable)
    {
        _container = container;
        _assetsAddressableService = assetsAddressableService;
        _foodEatObservable = foodEatObservable;
    }


    public IReadOnlyList<GameObject> Instances
    {
        get => _instances;
    }

    public async void CreateObject(Vector3 position, params FoodDecorator[] decorators)
    {
        FoodConfig foodConfig;

        foodConfig = await _assetsAddressableService.GetAsset<FoodConfig>(AssetsAddressesConstants.BASE_FOOD_CONFIG);
        
        FoodStats foodStats = GetUnitStatsFromConfig(foodConfig);

        GameObject foodInstance = SpawnGameObject(foodConfig);
        
        ToScene(foodInstance);
        
        DecorateStats(ref foodStats, decorators);
        
        SetUp(foodInstance, position, foodStats);
        
        _instances.Add(foodInstance);
    }

    public void DestroyInstance(GameObject instance)
    {
        if (instance == null)
        {
            throw new NullReferenceException("There is no instance to destroy");
        }
        
        Object.Destroy(instance);
    }

    public void DestroyAllInstances()
    {
        for (int i = 0; i < _instances.Count; i++)
        {
            Object.Destroy(_instances[i]);
        }
        
        _instances.Clear();
    }

    private FoodStats GetUnitStatsFromConfig(FoodConfig foodConfig)
    {
        return new FoodStats(
            foodConfig.Mesh,
            foodConfig.Color,
            foodConfig.Size,
            foodConfig.RecoveryValue,
            foodConfig.FoodType
        );
    }

    private GameObject SpawnGameObject(FoodConfig foodConfig)
    {
        if (foodConfig.Prefab == null)
        {
            throw new NullReferenceException($"There is no prefab on {foodConfig}");
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

    private void SetUp(GameObject foodInstance, Vector3 position, FoodStats foodStats)
    {
        foodInstance.transform.position = position;

        if (foodInstance.TryGetComponent(out IFood food))
        {
            food.Modify(foodStats.RecoveryValue, foodStats.FoodType);
            food.Construct(this);

            _foodEatObservable.Register(food);
        }

        if (foodInstance.TryGetComponent(out FoodMeshHandler meshHandler))
        {
            meshHandler.Modify(foodStats.Mesh, foodStats.Color, foodStats.Size);
        }
    }

    private void ToScene(GameObject target)
    {
        SceneManager.MoveGameObjectToScene(target, SceneManager.GetActiveScene());
    }
}
