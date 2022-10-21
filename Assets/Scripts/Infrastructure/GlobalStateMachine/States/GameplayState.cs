using UnityEngine;

public class GameplayState : StateThreeParams<GameInstance, GameplayScreen, GameObject, GameObject>
{
    public GameplayState(GameInstance context, IUIFactory uiFactory) : base(context)
    {
        _uiFactory = uiFactory;
    }

    private readonly IUIFactory _uiFactory;
    private GameplayScreen _gameplayScreen;
    private GameObject _playerInstance;
    private GameObject _cameraInstance;
    
    public override void Enter(GameplayScreen arg0, GameObject arg1, GameObject arg2)
    {
        _gameplayScreen = arg0;
        _playerInstance = arg1;
        _cameraInstance = arg2;

        _gameplayScreen.FloatingJoystick.gameObject.SetActive(true);
        _gameplayScreen.AttackButton.gameObject.SetActive(true);

        _playerInstance.GetComponent<IDamagable>().OnDied += OnDied;
        
        _uiFactory.DestroyLoadingScreen();
    }

    public override void Exit()
    {
        _playerInstance.GetComponent<IDamagable>().OnDied -= OnDied;
        _uiFactory.DestroyGameplayScreen();
    }

    private void OnDied()
    {
        Context.StateMachine.SwitchState<PlayerDiedState>();
        _cameraInstance.GetComponentInChildren<CameraFollowing>().enabled = false;
    }
}
