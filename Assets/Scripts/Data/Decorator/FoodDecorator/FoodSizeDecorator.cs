using UnityEngine;

public class FoodSizeDecorator : FoodDecorator
{
    [SerializeField][Min(0)] private float _size;
    [SerializeField] private float _recoveryValue;
    
    public override void Decorate(ref FoodStats sourceStats)
    {
        sourceStats.Size = _size;
        sourceStats.RecoveryValue += _recoveryValue;
    }
}
