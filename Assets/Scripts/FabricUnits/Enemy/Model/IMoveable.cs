using UnityEngine;

public interface IMoveable
{
    public float Speed { get; }

    public void Modify(float speed);
}
