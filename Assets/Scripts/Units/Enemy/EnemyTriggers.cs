using UnityEngine;
using UnityEngine.Events;

public class EnemyTriggers : MonoBehaviour
{
    public event UnityAction<int> OnFoodEaten;
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out IEatable eatable))
        {
            OnFoodEaten?.Invoke(eatable.RecoveryValue);
            eatable.DestroyInstance();
        }
    }
}
