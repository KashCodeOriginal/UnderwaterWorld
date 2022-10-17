using System.Collections.Generic;

public class FoodRelationService : IFoodRelationService
{
    private Dictionary<FoodChooseBehavior, FoodTypeBehavior[]> _foodTypeRelations = new Dictionary<FoodChooseBehavior, FoodTypeBehavior[]>()
    {
        {FoodChooseBehavior.Herbivorous, new[] {FoodTypeBehavior.Plant}},
        {FoodChooseBehavior.Сarnivorous, new []{FoodTypeBehavior.Meat}},
        {FoodChooseBehavior.Omnivorous, new []{FoodTypeBehavior.Plant, FoodTypeBehavior.Meat}}
    };

    public FoodTypeBehavior[] GetEatableFoodType(FoodChooseBehavior foodChoose)
    {
        return _foodTypeRelations[foodChoose];
    }
}