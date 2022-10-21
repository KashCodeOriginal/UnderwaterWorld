using UnityEngine;

public class PlayerAttack : MonoBehaviour, IAttackable
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private bool _isCooldown;
    public int BaseDamage
    {
        get => _damage;
    }

    public float AttackSpeed
    {
        get => _attackSpeed;
    }

    public bool IsCooldown
    {
        get => _isCooldown;
    }

    public void TryAttack(IDamagable damagable)
    {
        damagable.TryApplyDamage(BaseDamage, gameObject);
    }
}
