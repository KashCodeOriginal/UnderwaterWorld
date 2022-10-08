using System;
using Zenject;
using UnityEngine;
using System.Collections.Generic;
using Object = UnityEngine.Object;

public class AbstractFactory : IAbstractFactory
{
    public AbstractFactory(DiContainer container)
    {
        _container = container;
    }

    public IReadOnlyList<GameObject> Instances
    {
        get => _instances;
    }
    private readonly DiContainer _container;

    private List<GameObject> _instances = new List<GameObject>();
    
    public GameObject CreateObject(GameObject prefab, Vector3 spawnPoint)
    {
        GameObject instance = _container.InstantiatePrefab(prefab, spawnPoint, Quaternion.identity, null);
        
        _instances.Add(instance);

        return instance;
    }

    public void DestroyObject(GameObject instance)
    {
        if (instance == null)
        {
            throw new NullReferenceException("There is no instance to destroy");
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
}