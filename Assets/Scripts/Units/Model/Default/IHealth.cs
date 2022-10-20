public interface IHealth
{
    public int HealthPoints { get; }

    public void IncreaseHealth(int increaseValue);
    public void DecreaseHealth(int decreaseValue);
}
