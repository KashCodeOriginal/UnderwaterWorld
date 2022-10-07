using UnityEngine;
using UnityEngine.Events;

public class PlayerTriggers : MonoBehaviour
{
    public event UnityAction<int> OnFoodEaten;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IEatable eatable))
        {
            OnFoodEaten?.Invoke(eatable.RecoveryValue);
            
            Debug.Log(eatable.RecoveryValue);
            
            eatable.DestroyInstance();
        }
    }
}
