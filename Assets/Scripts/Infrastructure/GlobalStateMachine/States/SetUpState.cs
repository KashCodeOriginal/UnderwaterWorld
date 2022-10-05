using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SetUpState : State<GameInstance>
{
    public SetUpState(GameInstance context, IAbstractFactory iAbstractFactory, IAssetsAddressableService assetsAddressableService) : base(context)
    {
        _abstractFactory = iAbstractFactory;
        _assetsAddressableService = assetsAddressableService;
    }

    private readonly IAbstractFactory _abstractFactory;
    private readonly IAssetsAddressableService _assetsAddressableService;
    
    public override async void Enter()
    {
        var foodSpawner = Object.FindObjectOfType<FoodSpawner>();
        foodSpawner.CreateFood();

        GameObject player = await _assetsAddressableService.GetAsset<GameObject>(GameConstants.PLAYER_INSTANCE);
        GameObject camera = await _assetsAddressableService.GetAsset<GameObject>(GameConstants.CAMERA_INSTANCE);
        
        var playerInstance =_abstractFactory.CreateObject(player, new Vector3(0,1,0));
        var cameraInstance = _abstractFactory.CreateObject(camera, Vector3.zero);
        
        cameraInstance.GetComponentInChildren<CameraFollowing>().SetTarget(playerInstance.transform);

        Context.StateMachine.SwitchState<GameStartState>();
    }
}