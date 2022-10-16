using System;
using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using Zenject;
using Object = UnityEngine.Object;

public class EnemyFactory : IEnemyFactory
{
    public EnemyFactory(DiContainer container, IAssetsAddressableService assetsAddressableService)
    {
        _container = container;
        _assetsAddressableService = assetsAddressableService;
    }

    public event Action OnInstancesListChanged;

    public IReadOnlyList<GameObject> Instances
    {
        get => _instances;
    }

    private List<GameObject> _instances = new List<GameObject>();

    private readonly DiContainer _container;
    private readonly IAssetsAddressableService _assetsAddressableService;

    public async Task<GameObject> CreateObject(Vector3 position, params EnemyDecorator[] decorators)
    {
        EnemyConfig enemyConfig;

        enemyConfig = await _assetsAddressableService.GetAsset<EnemyConfig>(GameConstants.BASE_ENEMY_CONFIG);

        EnemyStats enemyStats = GetUnitStatsFromConfig(enemyConfig);

        GameObject enemyInstance = SpawnGameObject(enemyConfig);
        
        ToScene(enemyInstance);
        
        DecorateStats(ref enemyStats, decorators);
        
        SetUp(enemyInstance, position, enemyStats);
        
        _instances.Add(enemyInstance);

        return enemyInstance;
    }

    public void DestroyInstance(GameObject instance)
    {
        if (instance == null)
        {
            throw new NullReferenceException("There is no enemyInstance to destroy");
        }
        if (_instances.Contains(instance))
        {
            Object.Destroy(instance);
            _instances.Remove(instance);
        }
        else
        {
            throw new NullReferenceException($"Instance {instance} can't be destroyed, cause there is no {instance} on Abstract Factory Instances");
        }
    }

    public void DestroyAllInstances()
    {
        for (int i = 0; i < _instances.Count; i++)
        {
            Object.Destroy(_instances[i]);
        }
        
        _instances.Clear();
    }

    private EnemyStats GetUnitStatsFromConfig(EnemyConfig enemyConfig)
    {
        return new EnemyStats(
            enemyConfig.Health,
            enemyConfig.Damage,
            enemyConfig.Size,
            enemyConfig.Speed,
            enemyConfig.Mesh,
            enemyConfig.FoodChoose);
    }

    private GameObject SpawnGameObject(EnemyConfig enemyConfig)
    {
        if (enemyConfig.Prefab == null)
        {
            throw new NullReferenceException($"There is no prefab on {enemyConfig}");
        }

        GameObject foodInstance = _container.InstantiatePrefab(enemyConfig.Prefab);

        return foodInstance;
    }

    private void DecorateStats(ref EnemyStats enemyStats, params EnemyDecorator[] decorators)
    {
        for (int i = 0; i < decorators.Length; i++)
        {
            decorators[i].Decorate(ref enemyStats);
        }
    }

    private void SetUp(GameObject enemyInstance, Vector3 position, EnemyStats enemyStats)
    {
        enemyInstance.transform.position = position;

        if (enemyInstance.TryGetComponent(out Enemy enemy))
        {
            enemy.Modify(enemyStats.Health);
        }

        if (enemyInstance.TryGetComponent(out EnemyMeshHandler enemyMeshHandler))
        {
            enemyMeshHandler.Modify(enemyStats.Mesh, enemyStats.Size);
        }
        
        if (enemyInstance.TryGetComponent(out IAIMovable moveable))
        {
            moveable.Modify(enemyStats.Speed);
        }

        if (enemyInstance.TryGetComponent(out IAIAttackable attackable))
        {
            attackable.Modify(enemyStats.Damage);
        }
        
        if (enemyInstance.TryGetComponent(out IAIEatable eatable))
        {
            eatable.Modify(enemyStats.FoodChoose);
        }
    }

    private void ToScene(GameObject target)
    {
        SceneManager.MoveGameObjectToScene(target, SceneManager.GetActiveScene());
    }
}
