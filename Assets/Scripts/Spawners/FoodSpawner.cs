using UnityEngine;
using Zenject;
using System;
using Random = UnityEngine.Random;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private FoodMeshDecorator[] _meshDecorators = Array.Empty<FoodMeshDecorator>();

    [SerializeField] private FoodColorDecorator[] _colorDecorators = Array.Empty<FoodColorDecorator>();

    [SerializeField] private FoodSizeDecorator[] _sizeDecorators = Array.Empty<FoodSizeDecorator>();

    private IFoodFactory _foodFactory;
    private GameSettings _gameSettings;
    private IUnitsDeathObservable _unitsDeathObservable;

    [Inject]
    public void Construct(IFoodFactory foodFactory, GameSettings gameSettings, IUnitsDeathObservable unitsDeathObservable)
    {
        _foodFactory = foodFactory;
        _gameSettings = gameSettings;
        _unitsDeathObservable = unitsDeathObservable;
    }

    public void CreateFood(int amount, Vector3 position, bool isPositionRandom)
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
                
                CreateObject(randomPosition);
            }
            else
            {
                CreateObject(position);
            }
        }
    }
    
    private int GetRandomValue(int startValue, int endValue)
    {
        int randomValue = Random.Range(startValue, endValue);
        return randomValue;
    }

    private void CreateObject(Vector3 position)
    {
        _foodFactory.CreateObject(position, 
            _meshDecorators[GetRandomValue(0, _meshDecorators.Length)], 
            _colorDecorators[GetRandomValue(0, _colorDecorators.Length)], 
            _sizeDecorators[GetRandomValue(0, _sizeDecorators.Length)]);
    }

    private void UnitDied(IDamagable damagable)
    {
        CreateFood(3, damagable.GameObject.transform.position, false);
    }

    private void OnEnable()
    {
        _unitsDeathObservable.OnUnitDied += UnitDied;
    }
    private void OnDisable()
    {
        _unitsDeathObservable.OnUnitDied -= UnitDied;
    }
}
