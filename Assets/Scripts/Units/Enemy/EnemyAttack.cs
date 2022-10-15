using UnityEngine;

public class EnemyAttack : MonoBehaviour, IAttackable, IAIAttackable
{
    public int BaseDamage { get; private set; }
    
    public void Modify(int baseDamage)
    {
        BaseDamage = baseDamage;
    }
    
}
