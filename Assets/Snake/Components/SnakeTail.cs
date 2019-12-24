using Unity.Entities;

namespace snake
{
    public struct SnakeTail : IComponentData
    {
        public bool IsCreated;
        public int Number;

        public static SnakeTail Default{
            get
            {   
                var tail = new SnakeTail
                {
                    IsCreated = false
                };
                return tail;
            }
        }
    }
}

