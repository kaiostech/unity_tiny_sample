using Unity.Entities;
using Unity.Tiny.Scenes;

namespace snake
{
    public struct GameConfig : IComponentData
    {
        public float TickRate;
        public float LastFrameTime;
        public SceneReference SnakeTailSceneReference;
        public SceneReference FoodSceneReference;
        public bool FoodExist;
    }
}

