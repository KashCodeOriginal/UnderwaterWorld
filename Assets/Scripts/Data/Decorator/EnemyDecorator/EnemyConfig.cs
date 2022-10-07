using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDecoratorConfig", menuName = "Decorators/BaseConfigs/EnemyDecoratorConfig")]
public class EnemyConfig : ScriptableObject
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _size;
    [SerializeField] private int _speed;
    [SerializeField] private Mesh _mesh;
    [SerializeField] private GameObject _prefab;

    public int Health => _health;
    public int Damage => _damage;
    public float Size => _size;
    public float Speed => _speed;
    public Mesh Mesh => _mesh;
    public GameObject Prefab => _prefab;
}
