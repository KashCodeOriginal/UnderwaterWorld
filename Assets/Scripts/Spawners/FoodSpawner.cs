using UnityEngine;
using Zenject;
using System;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private int amount;

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
        for (int i = 0; i < amount; i++)
        {
            if (!isActiveAndEnabled)
            {
                return;
            }
            
            _foodFabric.CreateObject(new Vector3(0,0,0), _meshDecorators[UnityEngine.Random.Range(0, _meshDecorators.Length)], _colorDecorators[UnityEngine.Random.Range(0, _colorDecorators.Length)], _sizeDecorators[UnityEngine.Random.Range(0, _sizeDecorators.Length)]);
        }
    }
}
