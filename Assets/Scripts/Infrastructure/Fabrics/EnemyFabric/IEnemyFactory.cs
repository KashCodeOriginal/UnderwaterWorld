using System.Threading.Tasks;
using UnityEngine;

public interface IEnemyFactory : IEnemyInfo
{
    public Task<GameObject> CreateObject(Vector3 position, params EnemyDecorator[] decorators);
    public void DestroyInstance(GameObject instance);
    public void DestroyAllInstances();
}
