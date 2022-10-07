using System;
using Zenject;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

public class FoodFactory : IFoodFactory
{
    public FoodFactory(DiContainer container, IAssetsAddressableService assetsAddressableService)
    {
        _container = container;
        _assetsAddressableService = assetsAddressableService;
    }

    public event Action OnInstancesListChanged;

    public IReadOnlyList<GameObject> Instances
    {
        get => _instances;
    }

    private readonly DiContainer _container;
    private readonly IAssetsAddressableService _assetsAddressableService;

    private List<GameObject> _instances = new List<GameObject>();

    public async void CreateObject(Vector3 position, params FoodDecorator[] decorators)
    {
        FoodConfig foodConfig;

        foodConfig = await _assetsAddressableService.GetAsset<FoodConfig>(GameConstants.BASE_FOOD_CONFIG);
        
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
        
        //OnInstancesListChanged?.Invoke();
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
            foodConfig.RecoveryValue
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

        if (foodInstance.TryGetComponent(out Food food))
        {
            food.Modify(foodStats.RecoveryValue);
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
