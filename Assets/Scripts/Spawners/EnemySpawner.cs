using System;
using Zenject;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyMeshDecorator[] _meshDecorators = Array.Empty<EnemyMeshDecorator>();
    [SerializeField] private EnemySizeDecorator[] _colorDecorators = Array.Empty<EnemySizeDecorator>();

    private IUnitFactory _unitFactory;
    private IFoodRelationService _foodRelationService;
    private GameSettings _gameSettings;

    [Inject]
    public void Construct(IUnitFactory unitFactory, IFoodRelationService foodRelationService, GameSettings gameSettings)
    {
        _unitFactory = unitFactory;
        _foodRelationService = foodRelationService;
        _gameSettings = gameSettings;
    }

    public void CreateEnemy(int amount, Vector3 position, bool isPositionRandom)
    {
        for (int i = 0; i < amount; i++)
        {
            if (!isActiveAndEnabled)
            {
                return;
            }

            if (isPositionRandom)
            {
                var randomPosition = new Vector3(
                    Random.Range(_gameSettings.MapMinX, _gameSettings.MapMaxX), 
                    _gameSettings.PlayerSpawnPoint.y, 
                    Random.Range(_gameSettings.MapMinZ, _gameSettings.MapMaxZ));
                
                CreateUnit(randomPosition);
            }
            else
            {
                CreateUnit(position);
            }
        }
    }
    
    private int GetRandomValue(int startValue, int endValue)
    {
        int randomValue = Random.Range(startValue, endValue);
        return randomValue;
    }

    private async void CreateUnit(Vector3 position)
    {
        GameObject instance = await _unitFactory.CreateObject(position,
            _meshDecorators[GetRandomValue(0, _meshDecorators.Length)],
            _colorDecorators[GetRandomValue(0, _colorDecorators.Length)]);
            
        instance.GetComponent<UnitTriggers>().Construct(_foodRelationService);
        instance.GetComponent<EnemyMovement>().Construct(_gameSettings);
    }
}
