public interface IHunger
{
    public int HungerPoints { get; }

    public void IncreaseHunger(int increaseValue);
    public void DecreaseHunger(int decreaseValue);
}
