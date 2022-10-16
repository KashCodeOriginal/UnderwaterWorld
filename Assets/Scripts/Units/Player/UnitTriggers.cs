using UnityEngine;
using UnityEngine.Events;

public class UnitTriggers : MonoBehaviour
{
    public event UnityAction<int> OnFoodEaten;

    public IFoodRelationService _foodRelationService { get; private set; }

    public void Construct(IFoodRelationService foodRelationService)
    {
        _foodRelationService = foodRelationService;
    }

    private void OnTriggerEnter(Collider collider)
    {
        FoodTriggerEntered(collider);
    }

    private void FoodTriggerEntered(Collider collider)
    {
        if (collider.TryGetComponent(out IFood food))
        {
            if (gameObject.TryGetComponent(out IEatable eatable))
            {
                var foodTypes = _foodRelationService.GetEatableFoodType(eatable.FoodChoose);

                foreach (var foodType in foodTypes)
                {
                    if (foodType == food.FoodType)
                    {
                        OnFoodEaten?.Invoke(food.RecoveryValue);

                        food.DestroyInstance();
                        
                        return;
                    }
                }
            }
        }
    }
}
