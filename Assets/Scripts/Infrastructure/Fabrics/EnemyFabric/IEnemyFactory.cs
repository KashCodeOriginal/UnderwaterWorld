using UnityEngine;

public interface IEnemyFactory : IEnemyInfo
{
    public void CreateObject(Vector3 position, params EnemyDecorator[] decorators);
    public void DestroyInstance(GameObject instance);
    public void DestroyAllInstances();
}
