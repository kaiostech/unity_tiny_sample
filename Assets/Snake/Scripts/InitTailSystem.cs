using snake;
using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Scenes;

public class Init : ComponentSystem
{
    protected override void OnUpdate()
    {
        bool growTail = false;
        Entities.ForEach((Entity entity, ref SnakeHead snake) => {
            if (!snake.GrowTail)
            {
                return;
            }
            else
            {
                growTail = true;
                snake.GrowTail = false;
            }
        });
        if (growTail)
        {
            SceneService.LoadSceneAsync(World.TinyEnvironment().GetConfigData<GameConfig>().SnakeTailSceneReference);
        }

        Entities.ForEach((Entity entity, ref SnakeTail tail) => {
            var count = 0;
            if (tail.IsCreated)
            {
                return;
            }
            tail.IsCreated = true;

            Entities.ForEach((DynamicBuffer<SnakeSegment> segments) => {
                segments.Add(new SnakeSegment
                {
                    Reference = entity
                });
                count = segments.Length;
            });
            tail.Number = count;
        });
    }
}
