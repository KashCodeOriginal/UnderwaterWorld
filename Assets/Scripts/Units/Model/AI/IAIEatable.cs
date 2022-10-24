using Pathfinding;
using UnityEngine;

public interface IAIEatable : IEatable
{
    public Transform CurrentTarget { get; }
    public void TryFindClosestFood(AIDestinationSetter aiDestinationSetter);
    public void Modify(FoodChooseBehavior foodChoose);
}
