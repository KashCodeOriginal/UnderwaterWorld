using UnityEngine.Events;

public interface IFood
{
    public event UnityAction<IFood> WasEaten;
    public int RecoveryValue { get; }
    public FoodTypeBehavior FoodType { get; }
    public void Construct(IFoodFactory foodFactory) { }
    public void DestroyOnEat();
    public void Modify(int recoveryValue, FoodTypeBehavior foodType);
}
