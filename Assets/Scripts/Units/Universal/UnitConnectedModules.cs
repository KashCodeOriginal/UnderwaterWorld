using UnityEngine;
using System.Collections.Generic;

public class UnitConnectedModules : MonoBehaviour
{
    [SerializeField] private List<GameObject> _connectedModules;

    private IAttackable _unitAttackable;

    private void Start()
    {
        _unitAttackable = GetComponent<IAttackable>();
        
        foreach (var module in _connectedModules)
        {
            if (module.TryGetComponent(out IConnectableModule connectableModule))
            {
                connectableModule.Construct(_unitAttackable);
            }
        }
    }
}
