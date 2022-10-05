using System.Threading.Tasks;
using Object = UnityEngine.Object;
using UnityEngine.AddressableAssets;

public class AssetsAddressable : IAssetsAddressableService
{
    public async Task<T> GetAsset<T>(string path) where T : Object
    {
        var asyncOperationHandle = Addressables.LoadAssetAsync<T>(path);
        await asyncOperationHandle.Task;

        return asyncOperationHandle.Result;
    }
}
