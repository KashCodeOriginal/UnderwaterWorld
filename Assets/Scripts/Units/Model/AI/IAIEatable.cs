using Pathfinding;
using UnityEngine;

public interface IAIEatable
{
    public Transform CurrentFoodTarget { get; }
    public void TryFindClosestFood(AIDestinationSetter aiDestinationSetter);
}
