using System.Threading.Tasks;
using UnityEngine;

public interface IAssetsAddressableService : IService
{
    public Task<T> GetAsset<T>(string path) where T : Object;
}
