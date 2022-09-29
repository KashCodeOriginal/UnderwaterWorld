using UnityEngine;

public class LoadingState : State<GameInstance>
{
    public LoadingState(GameInstance context) : base(context) { }

    public override void Enter()
    {
        Debug.Log("2");
        Context.StateMachine.SwitchState<SetUpState>();
    }
}