using System.Threading.Tasks;
using UnityEngine;

public interface IEnemyFactory : IEnemyInfo, IFactory
{
    public Task<GameObject> CreateObject(Vector3 position, params EnemyDecorator[] decorators);
}
