using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;

    public int Health => _health;

    public void Modify(int health)
    {
        _health += health;
    }
}
