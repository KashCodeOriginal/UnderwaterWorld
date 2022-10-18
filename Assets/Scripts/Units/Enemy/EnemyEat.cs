using Pathfinding;
using UnityEngine;
using UnityEngine.Events;

public class EnemyEat : MonoBehaviour, IAIEatable
{
    public event UnityAction<int> IncreaseHunger;

    [SerializeField] private FoodChooseBehavior _foodChoose;
    
    private Enemy _enemy;

    private UnitTriggers _enemyTriggers;

    private IStatsService _statsService;

    private Transform _currentFoodTarget;

    private IFoodRelationService _foodRelationService;

    public Transform CurrentFoodTarget
    {
        get => _currentFoodTarget;
    }

    public FoodChooseBehavior FoodChoose
    {
        get => _foodChoose;
    }
    
    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _enemyTriggers = GetComponent<UnitTriggers>();

        _foodRelationService = _enemyTriggers._foodRelationService;
        
        _enemyTriggers.OnFoodEaten += TryIncreaseHunger;
    }

    public void TryFindClosestFood(AIDestinationSetter aiDestinationSetter)
    {
        if (aiDestinationSetter.target == _currentFoodTarget)
        {
            return;
        }
        
        var colliders = Physics.OverlapSphere(_enemy.transform.position, 15);
        
        var position = gameObject.transform.position;

        var closestCollider = FindClosestCollider(colliders, position);

        if (closestCollider != null)
        {
            FindClosestFood(closestCollider, aiDestinationSetter);
        }
    }

    public void Modify(FoodChooseBehavior foodChoose)
    {
        _foodChoose = foodChoose;
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

    private void FindClosestFood(Collider closestCollider, AIDestinationSetter aiDestinationSetter)
    {
        if (gameObject.TryGetComponent(out IEatable eatable))
        {
            var foodTypes = _foodRelationService.GetEatableFoodType(eatable.FoodChoose);

            var food = closestCollider.GetComponent<IFood>();

            foreach (var foodType in foodTypes)
            {
                if (foodType == food.FoodType)
                {
                    _currentFoodTarget = closestCollider.transform;
                }
                        
                if (_currentFoodTarget != null)
                {
                    aiDestinationSetter.target = _currentFoodTarget;
                }
            }
        }
    }

    private Collider FindClosestCollider(Collider[] colliders, Vector3 position)
    {
        Collider minDistanceCollider = null;
        var minDistance = Mathf.Infinity;

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out IFood _))
            {
                float distance = Vector3.Distance(position, collider.transform.position);

                if (distance < minDistance)
                {
                    minDistanceCollider = collider;
                    minDistance = distance;
                }
            }
        }

        return minDistanceCollider;
    }

    private void OnDisable()
    {
        _enemyTriggers.OnFoodEaten -= TryIncreaseHunger;
    }
}
