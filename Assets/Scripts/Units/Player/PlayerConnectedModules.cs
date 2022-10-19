using UnityEngine;
using System.Collections.Generic;

public class PlayerConnectedModules : MonoBehaviour
{
    [SerializeField] private List<GameObject> _connectedModules;

    private IAttackable _playerAttack;

    private void Start()
    {
        _playerAttack = GetComponent<IAttackable>();
        
        foreach (var module in _connectedModules)
        {
            if (module.TryGetComponent(out IConnectableModule connectableModule))
            {
                connectableModule.Construct(_playerAttack);
            }
        }
    }
}
