using UnityEngine;

public class UnitHunger : MonoBehaviour, IHunger
{
    public const int MAX_HUNGER_POINTS = 100;
    
    [SerializeField] private int _hungerPoints;
    
    private StatsService _statsService;
    
    private IEatable _eatable;

    public int HungerPoints
    {
        get => _hungerPoints;
    }

    private void Start()
    {
        _statsService = new StatsService();
        
        _hungerPoints = MAX_HUNGER_POINTS;

        _eatable = GetComponent<IEatable>();

        _eatable.IncreaseHunger += IncreaseHunger;
    }

    private void Update()
    {
        _statsService.DecreaseValue(ref _hungerPoints, 2, 3, 0);
    }

    public void IncreaseHunger(int increaseValue)
    {
        _hungerPoints += increaseValue;
    }

    public void DecreaseHunger(int decreaseValue)
    {
        _hungerPoints -= decreaseValue;
    }

    private void OnDisable()
    {
        _eatable.IncreaseHunger -= IncreaseHunger;
    }
}
