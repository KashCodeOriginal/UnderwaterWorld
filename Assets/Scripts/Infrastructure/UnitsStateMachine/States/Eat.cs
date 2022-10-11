using UnitsStateMachine;
using UnityEngine;

public class Eat : State
{
    public override void Tick()
    {
        Debug.Log("Ем");
    }
}
