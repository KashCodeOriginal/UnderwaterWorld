using UnityEngine;
using UnityEngine.Events;

public class EnemyEat : MonoBehaviour
{
    public event UnityAction<int> IncreaseHunger; 

    private Enemy _enemy;
    
    private EnemyTriggers _enemyTriggers;

    private IStatsService _statsService;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _enemyTriggers = GetComponent<EnemyTriggers>();
        _enemyTriggers.OnFoodEaten += TryIncreaseHunger;
    }

    private void TryIncreaseHunger(int increaseValue)
    {
        if (increaseValue <= 0)
        {
            throw new System.ArgumentOutOfRangeException($"{increaseValue} can't be 0 or less");
        }

        if (_enemy.HungerPoints + increaseValue <= Enemy.MAX_HUNGER_POINTS)
        {
            IncreaseHunger?.Invoke(increaseValue);
        }
        else
        {
            int maxAddableValue = Enemy.MAX_HUNGER_POINTS - _enemy.HungerPoints;

            IncreaseHunger?.Invoke(maxAddableValue);
        }
    }

    private void OnDisable()
    {
        _enemyTriggers.OnFoodEaten -= TryIncreaseHunger;
    }
}
