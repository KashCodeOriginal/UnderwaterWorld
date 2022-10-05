using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    public void MovePlayer(FloatingJoystick joystick)
    {
        _rigidbody.velocity = new Vector3(joystick.Horizontal * _speed, _rigidbody.velocity.y, joystick.Vertical * _speed);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            Quaternion _rotation = Quaternion.LookRotation(_rigidbody.velocity, Vector3.up);

            transform.rotation = new Quaternion(0, _rotation.y, 0, 0);
        }
        
    }
}
