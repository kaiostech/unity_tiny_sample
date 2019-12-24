using Unity.Entities;

namespace snake
{
    public struct SnakeSegment : IBufferElementData
    {
        public Entity Reference;
    }
}

