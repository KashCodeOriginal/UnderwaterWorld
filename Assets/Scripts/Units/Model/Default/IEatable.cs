using UnityEngine.Events;

public interface IEatable
{
    public FoodChooseBehavior FoodChoose { get; }
    public event UnityAction<int> IncreaseHunger;
}