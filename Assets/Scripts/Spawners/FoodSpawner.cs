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

    [SerializeField] private LayerMask _layerMask;

    private IFoodFactory _foodFactory;

    [Inject]
    public void Construct(IFoodFactory foodFactory)
    {
        _foodFactory = foodFactory;
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

            /*var colliders = Physics.OverlapSphere(position, 5 ,_layerMask);

            foreach (var collider in colliders)
            {
                Debug.Log(collider.name);
            }*/

            _foodFactory.CreateObject(position, 
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
