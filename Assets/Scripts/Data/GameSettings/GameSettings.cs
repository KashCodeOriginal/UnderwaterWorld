using Settings.Data;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Game/Settings/GameSettings")]
public class GameSettings : BaseSettings
{
    [SerializeField] private float _mapMinXPosition;
    [SerializeField] private float _mapMaxXPosition;
    [SerializeField] private float _mapMinZPosition;
    [SerializeField] private float _mapMaxZPosition;

    public float MapMinX => _mapMinXPosition;
    public float MapMaxX => _mapMaxXPosition;
    public float MapMinZ => _mapMinZPosition;
    public float MapMaxZ => _mapMaxZPosition;
}
