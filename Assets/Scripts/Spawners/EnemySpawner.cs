using System;
using Zenject;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _amount;
    
    [SerializeField] private float _minX, _maxX, _minZ, _maxZ;

    [SerializeField] private float _mapHeight;
    
    [SerializeField] private EnemyMeshDecorator[] _meshDecorators = Array.Empty<EnemyMeshDecorator>();
    [SerializeField] private EnemySizeDecorator[] _colorDecorators = Array.Empty<EnemySizeDecorator>();

    private IEnemyFactory _enemyFactory;
    private IFoodRelationService _foodRelationService;

    [Inject]
    public void Construct(IEnemyFactory enemyFactory, IFoodRelationService foodRelationService)
    {
        _enemyFactory = enemyFactory;
        _foodRelationService = foodRelationService;
    }

    public async void CreateEnemy()
    {
        for (int i = 0; i < _amount; i++)
        {
            if (!isActiveAndEnabled)
            {
                return;
            }

            Vector3 position = new Vector3(Random.Range(_minX, _maxX), _mapHeight, Random.Range(_minZ, _maxZ));

            GameObject instance = await _enemyFactory.CreateObject(position,
                _meshDecorators[GetRandomValue(0, _meshDecorators.Length)],
                _colorDecorators[GetRandomValue(0, _colorDecorators.Length)]);
            
            instance.GetComponent<UnitTriggers>().Construct(_foodRelationService);
        }
    }
    
    private int GetRandomValue(int startValue, int endValue)
    {
        int randomValue = Random.Range(startValue, endValue);
        return randomValue;
    }
}
