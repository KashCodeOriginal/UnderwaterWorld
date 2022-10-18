using UnityEngine;

public class GameplaySetUpState : State<GameInstance>
{
    public GameplaySetUpState(GameInstance context, IUIFactory uiFactory, IFoodRelationService foodRelationService, IAbstractFactory abstractFactory, IAssetsAddressableService assetsAddressableService) : base(context)
    {
        _uiFactory = uiFactory;
        _foodRelationService = foodRelationService;
        _abstractFactory = abstractFactory;
        _assetsAddressableService = assetsAddressableService;
    }

    private readonly IUIFactory _uiFactory;
    private readonly IFoodRelationService _foodRelationService;
    private readonly IAbstractFactory _abstractFactory;
    private readonly IAssetsAddressableService _assetsAddressableService;

    private GameObject _gameplayScreen;

    public override async void Enter()
    {
        ShowUI();
        
        GameObject map = await _assetsAddressableService.GetAsset<GameObject>(AssetsAddressesConstants.MAP_INSTANCE);
        GameObject pathfinding = await _assetsAddressableService.GetAsset<GameObject>(AssetsAddressesConstants.PATHFINDING_INSTANCE);
        GameObject player = await _assetsAddressableService.GetAsset<GameObject>(AssetsAddressesConstants.PLAYER_INSTANCE);
        GameObject camera = await _assetsAddressableService.GetAsset<GameObject>(AssetsAddressesConstants.CAMERA_INSTANCE);

        _abstractFactory.CreateObject(map, Vector3.zero);
        _abstractFactory.CreateObject(pathfinding, Vector3.zero);
        
        var playerInstance =_abstractFactory.CreateObject(player, new Vector3(0,1,0));
        var cameraInstance = _abstractFactory.CreateObject(camera, Vector3.zero);
        
        var foodSpawner = Object.FindObjectOfType<FoodSpawner>();
        foodSpawner.CreateFood();

        var enemySpawner = Object.FindObjectOfType<EnemySpawner>();
        enemySpawner.CreateEnemy();

        if(_gameplayScreen.TryGetComponent(out GameplayScreen gameplayScreen))
        {
            playerInstance.GetComponent<PlayerInput>().SetJoystick(gameplayScreen.FloatingJoystick);
        }

        playerInstance.GetComponent<UnitTriggers>().Construct(_foodRelationService);
        
        cameraInstance.GetComponentInChildren<CameraFollowing>().SetTarget(playerInstance.transform);
        
        Context.StateMachine.SwitchState<GameplayState, GameplayScreen>(gameplayScreen);
    }

    private async void ShowUI()
    {
        _uiFactory.CreateLoadingScreen();
        
        _gameplayScreen = await _uiFactory.CreateGameplayScreen();
    }
}