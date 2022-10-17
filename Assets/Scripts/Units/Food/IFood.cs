using UnityEngine;

public interface IFood
{
    public int RecoveryValue { get; }
    public FoodTypeBehavior FoodType { get; }
    public void Construct(IFoodFactory foodFactory) { }
    public void DestroyOnEat();
    public void Modify(int recoveryValue, FoodTypeBehavior foodType);
}
