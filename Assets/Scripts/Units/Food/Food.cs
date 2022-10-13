using UnityEngine;

public class Food : MonoBehaviour, IEatable
{
    public int RecoveryValue => _recoveryValue;
    
    [SerializeField] private int _recoveryValue;

    public void Modify(int recoveryValue)
    {
        _recoveryValue += recoveryValue;
    }
    
    public void DestroyInstance()
    {
        Destroy(gameObject);
    }
}
