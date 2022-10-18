using Pathfinding;
using UnityEngine;

public interface IAIEatable : IEatable
{
    public Transform CurrentFoodTarget { get; }
    public void TryFindClosestFood(AIDestinationSetter aiDestinationSetter);
    public void Modify(FoodChooseBehavior foodChoose);
}
