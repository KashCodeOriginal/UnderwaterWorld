using UnityEngine;

public class PlayerAttack : MonoBehaviour, IAttackable
{
    [SerializeField] private int _damage;

    public int BaseDamage
    {
        get => _damage;
    }
}
