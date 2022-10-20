using UnityEngine;

public interface IAbstractFactory : IAbstactFactoryInfo, IFactory
{
   public GameObject CreateObject(GameObject prefab, Vector3 spawnPoint);
}
