using UnityEngine;

public interface IAIMoveable
{
    public float MinWalkableX { get; }
    public float MaxWalkableX { get; }
    public float MinWalkableZ { get; }
    public float MaxWalkableZ { get; }
    
    public float MapHeight { get; }
    
    public float MinWalkableDistance { get; }
    public float MaxWalkableDistance { get; }
    
    public float ReachedPointDistance { get; }
} 