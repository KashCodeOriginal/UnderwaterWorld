using System.Collections.Generic;

public interface IFoodEatObservable
{
    
    public List<IFood> Instances { get; }

    public void Register(IFood food);
}