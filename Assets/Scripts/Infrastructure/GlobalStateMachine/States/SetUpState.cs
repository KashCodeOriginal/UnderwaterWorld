using UnityEngine;

public class SetUpState : State<GameInstance>
{
    public SetUpState(GameInstance context) : base(context) { }

    public override void Enter()
    {
        Debug.Log("3");
        Context.StateMachine.SwitchState<SimulationState>();
    }
}