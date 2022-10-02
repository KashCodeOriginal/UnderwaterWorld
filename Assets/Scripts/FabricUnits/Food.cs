using UnityEngine;

public class Food : MonoBehaviour, IEatable
{
    public float RecoveryValue => _recoveryValue;

    private float _recoveryValue;

    public void Modify(float recoveryValue)
    {
        _recoveryValue = recoveryValue;
    }
}
