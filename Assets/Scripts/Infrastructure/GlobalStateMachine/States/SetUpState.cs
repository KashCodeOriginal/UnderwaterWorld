using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SetUpState : State<GameInstance>
{
    public SetUpState(GameInstance context, IAbstractFactory iAbstractFactory) : base(context)
    {
        _abstractFactory = iAbstractFactory;
    }

    private readonly IAbstractFactory _abstractFactory;
    
    public override async void Enter()
    {
        var foodSpawner = Object.FindObjectOfType<FoodSpawner>();
        foodSpawner.CreateFood();

        GameObject player = await GetObjectFromAddressable(GameConstants.PLAYER_INSTANCE);
        GameObject camera = await GetObjectFromAddressable(GameConstants.CAMERA_INSTANCE);
        
        var playerInstance =_abstractFactory.CreateObject(player, Vector3.zero);
        var cameraInstance = _abstractFactory.CreateObject(camera, Vector3.zero);
        
        cameraInstance.GetComponentInChildren<CameraFollowing>().SetTarget(playerInstance.transform);

        Context.StateMachine.SwitchState<GameStartState>();
    }

    private async Task<GameObject> GetObjectFromAddressable(string path)
    {
        var asyncOperationHandle = Addressables.LoadAssetAsync<GameObject>(path);
        await asyncOperationHandle.Task;

        var prefab = asyncOperationHandle.Result;
        
        return prefab;
    }
}