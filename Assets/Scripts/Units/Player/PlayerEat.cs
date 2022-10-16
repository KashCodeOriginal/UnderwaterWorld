using UnityEngine;

public class PlayerEat : MonoBehaviour, IEatable
{
    [SerializeField] private int _hungerPoints;
    private int _maxHungerPoints = 100;
    
    private UnitTriggers _unitTriggers;

    [SerializeField] private FoodChooseBehavior _foodChoose;

    public FoodChooseBehavior FoodChoose
    {
        get => _foodChoose;
    }

    private void Start()
    {
        _unitTriggers = GetComponent<UnitTriggers>();
        
        _unitTriggers.OnFoodEaten += IncreaseHunger;
        
        _hungerPoints = _maxHungerPoints;
    }

    public int HungerPoint => _hungerPoints;
    
    private void IncreaseHunger(int increaseValue)
    {
        if (increaseValue <= 0)
        {
            throw new System.ArgumentOutOfRangeException($"{increaseValue} can't be 0 or less");
        }

        if (_hungerPoints + increaseValue <= _maxHungerPoints)
        {
            _hungerPoints += increaseValue;
        }
        else
        {
            int maxAddableValue = _maxHungerPoints - _hungerPoints;

            _hungerPoints += maxAddableValue;
        }
    }

    private void OnDisable()
    {
        _unitTriggers.OnFoodEaten -= IncreaseHunger;
    }

    
}
