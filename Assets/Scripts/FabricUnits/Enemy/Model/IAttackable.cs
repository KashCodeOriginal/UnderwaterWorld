public interface IAttackable
{
    public int BaseDamage { get; }

    public void Modify(int baseDamage);
}
