using Pathfinding;
using UnityEngine;
using UnityEngine.Events;

public class EnemyEat : MonoBehaviour, IAIEatable
{
    public event UnityAction<int> IncreaseHunger; 

    private Enemy _enemy;
    
    private EnemyTriggers _enemyTriggers;

    private IStatsService _statsService;

    [SerializeField] private Transform _currentFoodTarget;

    public Transform CurrentFoodTarget
    {
        get => _currentFoodTarget;
    }
    

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _enemyTriggers = GetComponent<EnemyTriggers>();
        _enemyTriggers.OnFoodEaten += TryIncreaseHunger;
    }

    public void TryFindClosestFood(AIDestinationSetter aiDestinationSetter)
    {
        var colliders = Physics.OverlapSphere(_enemy.transform.position, 10);
        
        foreach (var collider in colliders)
        {
            if (aiDestinationSetter.target == _currentFoodTarget)
            {
                return;
            }

            _currentFoodTarget = collider.TryGetComponent(out IEatable eatable) ? collider.transform : null;

            if (_currentFoodTarget != null)
            {
                aiDestinationSetter.target = _currentFoodTarget;
            }
        }
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
