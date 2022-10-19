using UnityEngine;
using UnityEngine.Events;

public class PlayerEat : MonoBehaviour, IEatable
{
    [SerializeField] private FoodChooseBehavior _foodChoose;
    
    private UnitTriggers _unitTriggers;

    private Player _player;
    
    public FoodChooseBehavior FoodChoose
    {
        get => _foodChoose;
    }

    public event UnityAction<int> IncreaseHunger;

    private void Start()
    {
        _unitTriggers = GetComponent<UnitTriggers>();

        _player = GetComponent<Player>();
        
        _unitTriggers.OnFoodEaten += TryIncreaseHunger;
    }
    
    
    private void TryIncreaseHunger(int increaseValue)
    {
        if (increaseValue <= 0)
        {
            throw new System.ArgumentOutOfRangeException($"{increaseValue} can't be 0 or less");
        }

        if (_player.HungerPoints + increaseValue <= Player.MAX_HUNGER_POINTS)
        {
            IncreaseHunger?.Invoke(increaseValue);
        }
        else
        {
            int maxAddableValue = Player.MAX_HUNGER_POINTS - _player.HungerPoints;

            IncreaseHunger?.Invoke(maxAddableValue);
        }
    }

    private void OnDisable()
    {
        _unitTriggers.OnFoodEaten -= TryIncreaseHunger;
    }
}
