using Pathfinding;
using UnityEngine;
using UnityEngine.Events;

public interface IAIMovable : IMovable
{
    public event UnityAction IsUnitEscaped;
    public float MinWalkableDistance { get; }
    public float MaxWalkableDistance { get; }
    
    public float ReachedPointDistance { get; }

    public void MoveToRandomPoint(AIDestinationSetter aiDestinationSetter);
    public void MoveAwayFromAttacker(AIDestinationSetter aiDestinationSetter, Transform attackerTransform);

    public void Modify(float speed);
} 