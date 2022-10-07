using UnityEngine;

[CreateAssetMenu(fileName = "FoodColorDecorator", menuName = "Decorators/FoodDecorators/FoodColorDecorator")]
public class FoodColorDecorator : FoodDecorator
{
    [SerializeField] private Color _color;
    [SerializeField] private int _recoveryValue;
    
    public override void Decorate(ref FoodStats sourceStats)
    {
        sourceStats.Color = _color;
        sourceStats.RecoveryValue += _recoveryValue;
    }
}
