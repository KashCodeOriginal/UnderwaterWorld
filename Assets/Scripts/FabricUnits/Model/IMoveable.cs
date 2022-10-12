using Pathfinding;
using UnityEngine;

public interface IMoveable
{
    public float Speed { get; }

    public void MoveToRandomPoint(AIDestinationSetter aiDestinationSetter);

    public void Modify(float speed);
}
