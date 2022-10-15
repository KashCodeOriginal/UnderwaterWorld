using UnityEngine;

[CreateAssetMenu(fileName = "EnemyMeshDecorator", menuName = "Decorators/EnemyDecorator/EnemyMeshDecorator")]
public class EnemyMeshDecorator : EnemyDecorator
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private Mesh _mesh;
    [SerializeField] private FoodChooseBehavior _foodChoose;

    public override void Decorate(ref EnemyStats sourceStats)
    {
        sourceStats.Health += _health;
        sourceStats.Damage += _damage;
        sourceStats.Speed += _speed;
        sourceStats.Mesh = _mesh;
        sourceStats.FoodChoose = _foodChoose;
    }
}
