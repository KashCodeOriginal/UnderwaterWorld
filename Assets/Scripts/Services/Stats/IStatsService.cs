public interface IStatsService : IService
{
    public void IncreaseValue(ref int value, float timeBetweenChange, int changeStep, float maxValue);
    public void DecreaseValue(ref int value, float timeBetweenChange, int changeStep, float minValue);
}
