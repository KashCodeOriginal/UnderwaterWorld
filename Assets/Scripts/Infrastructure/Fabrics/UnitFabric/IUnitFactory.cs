using System.Threading.Tasks;
using UnityEngine;

public interface IUnitFactory : IUnitInfo, IFactory
{
    public Task<GameObject> CreateObject(Vector3 position, params EnemyDecorator[] decorators);
}
