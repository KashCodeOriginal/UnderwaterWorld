public interface IFood
{
    public int RecoveryValue { get; }
    public FoodTypeBehavior FoodType { get; }
    public void DestroyInstance();
    public void Modify(int recoveryValue, FoodTypeBehavior foodType);
}
