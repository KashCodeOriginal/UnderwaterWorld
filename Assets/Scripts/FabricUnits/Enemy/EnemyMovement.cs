using UnityEngine;

public class EnemyMovement : MonoBehaviour, IMoveable
{
    public float Speed { get; private set; }
    
    public void Modify(float speed)
    {
        Speed = speed;
    }
}
