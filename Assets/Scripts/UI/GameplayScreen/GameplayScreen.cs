using UnityEngine;
using UnityEngine.UI;

public class GameplayScreen : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _floatingJoystick;
    [SerializeField] private Button _attackButton;

    public FloatingJoystick FloatingJoystick => _floatingJoystick;
    public Button AttackButton => _attackButton;
}
