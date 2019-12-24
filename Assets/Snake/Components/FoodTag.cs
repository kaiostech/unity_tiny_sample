using Unity.Entities;

namespace snake
{
    public struct FoodTag : IComponentData
    {
        public bool ShouldMove;
        public static FoodTag Default { get; } = new FoodTag
        {
            ShouldMove = true
        };

    }
}
