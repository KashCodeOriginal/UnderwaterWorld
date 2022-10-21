using UnityEngine;

public class EnemyAttack : MonoBehaviour, IAIAttackable
{
    public int BaseDamage { get; private set; }
    public float AttackSpeed { get; }
    public bool IsCooldown { get; }
    public void TryAttack(IDamagable damagable)
    {
        damagable.TryApplyDamage(BaseDamage, gameObject);
    }

    public void Modify(int baseDamage)
    {
        BaseDamage += baseDamage;
    }
    
}
