using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _floatingJoystick;

    private void FixedUpdate()
    {
        gameObject.GetComponent<PlayerMovement>().MovePlayer(_floatingJoystick);
    }

    public void SetJoystick(FloatingJoystick joystick)
    {
        _floatingJoystick = joystick;
    }
}
