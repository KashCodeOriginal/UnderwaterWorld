using System;
using Object = UnityEngine.Object;
using UnityEngine.AddressableAssets;

public class AssetsAddressable : IAssetsAddressableService
{
    public T GetAsset<T>(string path) where T : Object
    {
        var asyncOperationHandle = Addressables.LoadAssetAsync<T>(path);

        if (asyncOperationHandle.Result == null)
        {
            throw new Exception($"File path {path} doesn't contains any object");
        }
        return asyncOperationHandle.Result;
    }
}
