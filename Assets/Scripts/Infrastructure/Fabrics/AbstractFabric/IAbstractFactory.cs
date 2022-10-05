using UnityEngine;

public interface IAbstractFactory : IAbstactFactoryInfo
{
   public GameObject CreateObject(GameObject prefab, Vector3 spawnPoint);
   public void DestroyObject(GameObject instance);
}
