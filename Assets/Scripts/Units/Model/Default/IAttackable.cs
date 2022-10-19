public interface IAttackable
{
    public int BaseDamage { get; }
    public float AttackSpeed { get; }
    public bool IsCooldown { get; }

    public void TryAttack(IDamagable damagable);
}
