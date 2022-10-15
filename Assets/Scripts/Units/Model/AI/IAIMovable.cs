using Pathfinding;

public interface IAIMovable
{
    public float MinWalkableX { get; }
    public float MaxWalkableX { get; }
    public float MinWalkableZ { get; }
    public float MaxWalkableZ { get; }
    
    public float MinWalkableDistance { get; }
    public float MaxWalkableDistance { get; }
    
    public float ReachedPointDistance { get; }
    
    public void MoveToRandomPoint(AIDestinationSetter aiDestinationSetter);

    public void Modify(float speed);
} 