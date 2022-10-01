using System;
using Zenject;
using UnityEngine;
using System.Collections.Generic;

public class FoodFabric : IFoodFabric
{
    public event Action OnInstancesListChanged;

    public IReadOnlyList<GameObject> Instances
    {
        get => _instances;
    }

    private readonly DiContainer _container;
    private readonly ISceneInfoService _sceneInfoService;

    private List<GameObject> _instances;

    public FoodFabric(DiContainer container, ISceneInfoService sceneInfoService)
    {
        _container = container;
        _sceneInfoService = sceneInfoService;
    }
    

    public GameObject CreateObject(Vector3 position, params FoodDecorator[] decorators)
    {
        return new GameObject();
    }

    public void DestroyInstance()
    {
        throw new NotImplementedException();
    }

    public void DestroyAllInstances()
    {
        throw new NotImplementedException();
    }
}
