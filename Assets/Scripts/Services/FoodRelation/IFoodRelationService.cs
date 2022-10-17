public interface IFoodRelationService : IService
{
    public FoodTypeBehavior[] GetEatableFoodType(FoodChooseBehavior foodChoose);
}