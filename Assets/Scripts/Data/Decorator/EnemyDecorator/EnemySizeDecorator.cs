using UnityEngine;

[CreateAssetMenu(fileName = "EnemySizeDecorator", menuName = "Decorators/EnemyDecorator/EnemySizeDecorator")]
public class EnemySizeDecorator : EnemyDecorator
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _size;
    
    public override void Decorate(ref EnemyStats sourceStats)
    {
        sourceStats.Health += _health;
        sourceStats.Damage += _damage;
        sourceStats.Speed += _speed;
        sourceStats.Size = _size;
    }
}
