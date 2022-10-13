using UnityEngine;

public class StatsService : IStatsService
{
    private float _passedIncreasingTime;
    private float _passedDecreasingTime;
    
    public void IncreaseValue(ref int value, float timeBetweenChange,int changeStep, float maxValue)
    {
        if (value >= maxValue)
        {
            return;
        }

        _passedIncreasingTime += Time.deltaTime;

        if (_passedIncreasingTime >= timeBetweenChange)
        {
            value += changeStep;
            _passedIncreasingTime = 0;
        }
    }

    public void DecreaseValue(ref int value, float timeBetweenChange, int changeStep, float minValue)
    {
        if (value <= minValue)
        {
            return;
        }
        
        _passedDecreasingTime += Time.deltaTime;

        if (_passedDecreasingTime >= timeBetweenChange)
        {
            value -= changeStep;
            _passedDecreasingTime = 0;
        }
    }
}
