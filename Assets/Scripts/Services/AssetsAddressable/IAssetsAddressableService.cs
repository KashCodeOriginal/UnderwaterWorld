using UnityEngine;

public interface IAssetsAddressableService : IService
{
    public T GetAsset<T>(string path) where T : Object;
}
