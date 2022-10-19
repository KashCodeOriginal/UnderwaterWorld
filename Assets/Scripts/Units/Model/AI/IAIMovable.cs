using Pathfinding;

public interface IAIMovable : IMovable
{
    public float MinWalkableDistance { get; }
    public float MaxWalkableDistance { get; }
    
    public float ReachedPointDistance { get; }
    
    public void MoveToRandomPoint(AIDestinationSetter aiDestinationSetter);

    public void Modify(float speed);
} 