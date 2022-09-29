using UnityEngine;

public class SimulationState : State<GameInstance>
{
    public SimulationState(GameInstance context) : base(context) { }

    public override void Enter()
    {
        Debug.Log("4");
    }
}