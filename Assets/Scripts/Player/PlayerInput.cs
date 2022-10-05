using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private FloatingJoystick _floatingJoystick;
    
    private void FixedUpdate()
    {
        gameObject.GetComponent<PlayerMovement>().MovePlayer(_floatingJoystick);
    }
}
