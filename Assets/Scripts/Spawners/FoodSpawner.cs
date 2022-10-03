using UnityEngine;
using Zenject;
using System;
using Random = UnityEngine.Random;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private int _amount;
    
    [SerializeField] private float _minX, _maxX, _minZ, _maxZ;

    [SerializeField] private float _mapHeight;

    [SerializeField] private FoodMeshDecorator[] _meshDecorators = Array.Empty<FoodMeshDecorator>();

    [SerializeField] private FoodColorDecorator[] _colorDecorators = Array.Empty<FoodColorDecorator>();

    [SerializeField] private FoodSizeDecorator[] _sizeDecorators = Array.Empty<FoodSizeDecorator>();

    private IFoodFabric _foodFabric;

    [Inject]
    public void Construct(IFoodFabric foodFabric)
    {
        _foodFabric = foodFabric;
    }
    
    public void CreateFood()
    {
        for (int i = 0; i < _amount; i++)
        {
            if (!isActiveAndEnabled)
            {
                return;
            }

            Vector3 position = new Vector3(Random.Range(_minX, _maxX), _mapHeight, Random.Range(_minZ, _maxZ));
            
            _foodFabric.CreateObject(position, 
                _meshDecorators[GetRandomValue(0, _meshDecorators.Length)], 
                _colorDecorators[GetRandomValue(0, _colorDecorators.Length)], 
                _sizeDecorators[GetRandomValue(0, _sizeDecorators.Length)]);
        }
    }

    private int GetRandomValue(int startValue, int endValue)
    {
        int randomValue = Random.Range(startValue, endValue);
        return randomValue;
    }
}
