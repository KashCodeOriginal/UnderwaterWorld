using Pathfinding;
using UnityEngine;
using UnityEngine.Events;

public interface IAIEatable
{
    public event UnityAction<int> IncreaseHunger;
    public Transform CurrentFoodTarget { get; }
    public void TryFindClosestFood(AIDestinationSetter aiDestinationSetter);
    public void Modify(FoodChooseBehavior foodChoose);
}
