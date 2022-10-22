using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;

    public float Speed => _speed;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    public void MovePlayer(FloatingJoystick joystick)
    {
        _rigidbody.velocity = new Vector3(joystick.Horizontal * _speed, _rigidbody.velocity.y, joystick.Vertical * _speed);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }
        
    }
}
