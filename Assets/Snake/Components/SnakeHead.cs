using Unity.Entities;
using Unity.Mathematics;
using Unity.Authoring.Core;

namespace snake
{
    public struct SnakeHead : IComponentData
    {
        [HideInInspector]
        public float3 Direction;
        public float3 LastPosition;
        public bool GrowTail;
    }
}

