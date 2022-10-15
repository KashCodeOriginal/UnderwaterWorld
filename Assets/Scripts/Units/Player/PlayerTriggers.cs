using UnityEngine;
using UnityEngine.Events;

public class PlayerTriggers : MonoBehaviour
{
    public event UnityAction<int> OnFoodEaten;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IFood food))
        {
            OnFoodEaten?.Invoke(food.RecoveryValue);

            food.DestroyInstance();
        }
    }
}
