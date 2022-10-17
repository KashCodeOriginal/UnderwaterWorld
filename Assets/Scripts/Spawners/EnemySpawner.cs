using System;
using Zenject;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _amount;

    [SerializeField] private float _mapHeight;
    
    [SerializeField] private EnemyMeshDecorator[] _meshDecorators = Array.Empty<EnemyMeshDecorator>();
    [SerializeField] private EnemySizeDecorator[] _colorDecorators = Array.Empty<EnemySizeDecorator>();

    private IEnemyFactory _enemyFactory;
    private IFoodRelationService _foodRelationService;
    private GameSettings _gameSettings;

    [Inject]
    public void Construct(IEnemyFactory enemyFactory, IFoodRelationService foodRelationService, GameSettings gameSettings)
    {
        _enemyFactory = enemyFactory;
        _foodRelationService = foodRelationService;
        _gameSettings = gameSettings;
    }

    public async void CreateEnemy()
    {
        for (int i = 0; i < _amount; i++)
        {
            if (!isActiveAndEnabled)
            {
                return;
            }

            Vector3 position = new Vector3(
                Random.Range(_gameSettings.MapMinX, _gameSettings.MapMaxX), 
                _mapHeight, 
                Random.Range(_gameSettings.MapMinZ, _gameSettings.MapMaxZ));

            GameObject instance = await _enemyFactory.CreateObject(position,
                _meshDecorators[GetRandomValue(0, _meshDecorators.Length)],
                _colorDecorators[GetRandomValue(0, _colorDecorators.Length)]);
            
            instance.GetComponent<UnitTriggers>().Construct(_foodRelationService);
            instance.GetComponent<EnemyMovement>().Construct(_gameSettings);
        }
    }
    
    private int GetRandomValue(int startValue, int endValue)
    {
        int randomValue = Random.Range(startValue, endValue);
        return randomValue;
    }
}
