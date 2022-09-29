using UnityEngine;

public class BootstrapState : State<GameInstance>
{
    public BootstrapState(GameInstance context) : base(context) { }

    public override void Enter()
    {
        Debug.Log("1");
        Context.StateMachine.SwitchState<LoadingState>();
    }
}