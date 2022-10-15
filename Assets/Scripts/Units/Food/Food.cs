using UnityEngine;

public class Food : MonoBehaviour, IFood
{
    [SerializeField] private int _recoveryValue;
    
    [SerializeField] private FoodTypeBehavior _foodType;

    public int RecoveryValue
    {
        get => _recoveryValue;
    }

    public FoodTypeBehavior FoodType
    {
        get => _foodType;
    }

    public void Modify(int recoveryValue, FoodTypeBehavior foodType)
    {
        _recoveryValue += recoveryValue;
        _foodType = foodType;
    }
    
    public void DestroyInstance()
    {
        Destroy(gameObject);
    }
}
