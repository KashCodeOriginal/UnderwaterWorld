using UnityEngine;
using UnityEngine.Events;

public class EnemyTriggers : MonoBehaviour
{
    public event UnityAction<int> OnFoodEaten;
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out IFood food))
        {
            OnFoodEaten?.Invoke(food.RecoveryValue);
            food.DestroyInstance();
        }
    }
}
