using UnityEngine;

public class GameplayState : State<GameInstance>
{
    public GameplayState(GameInstance context, IUIFactory uiFactory, IAbstractFactory abstractFactory, IAssetsAddressableService assetsAddressableService, IFoodRelationService foodRelationService) : base(context)
    {
        _uiFactory = uiFactory;
        _abstractFactory = abstractFactory;
        _assetsAddressableService = assetsAddressableService;
        _foodRelationService = foodRelationService;
    }

    private readonly IUIFactory _uiFactory;
    private readonly IAbstractFactory _abstractFactory;
    private readonly IAssetsAddressableService _assetsAddressableService;
    private readonly IFoodRelationService _foodRelationService;

    private GameObject _gameplayScreen;

    public override async void Enter()
    {
        ShowUI();
        
        GameObject player = await _assetsAddressableService.GetAsset<GameObject>(GameConstants.PLAYER_INSTANCE);
        GameObject camera = await _assetsAddressableService.GetAsset<GameObject>(GameConstants.CAMERA_INSTANCE);
        
        var playerInstance =_abstractFactory.CreateObject(player, new Vector3(0,1,0));
        var cameraInstance = _abstractFactory.CreateObject(camera, Vector3.zero);
        
        playerInstance.GetComponent<PlayerInput>().SetJoystick(_gameplayScreen.GetComponentInChildren<FloatingJoystick>());
        playerInstance.GetComponent<UnitTriggers>().Construct(_foodRelationService);
        
        cameraInstance.GetComponentInChildren<CameraFollowing>().SetTarget(playerInstance.transform);
    }

    private async void ShowUI()
    {
        _gameplayScreen = await _uiFactory.CreateGameplayScreen();
    }

    private void HideUI()
    {
        _uiFactory.DestroyGameplayScreen();
    }
}