using UnityEngine;

public class Food : MonoBehaviour, IFood
{
    [SerializeField] private int _recoveryValue;
    
    [SerializeField] private FoodTypeBehavior _foodType;

    private IFoodFactory _foodFactory;

    public int RecoveryValue
    {
        get => _recoveryValue;
    }

    public FoodTypeBehavior FoodType
    {
        get => _foodType;
    }

    public void Construct(IFoodFactory foodFactory)
    {
        _foodFactory = foodFactory;
    }

    public void Modify(int recoveryValue, FoodTypeBehavior foodType)
    {
        _recoveryValue += recoveryValue;
        _foodType = foodType;
    }

    public void DestroyOnEat()
    {
        _foodFactory.DestroyInstance(gameObject);
    }
}
