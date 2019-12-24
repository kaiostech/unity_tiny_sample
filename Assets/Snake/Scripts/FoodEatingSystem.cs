using Unity.Entities;
using UnityEngine;
using Unity.Mathematics;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Random = Unity.Mathematics.Random;
using Unity.Tiny.Scenes;

namespace snake
{
    public class FoodEatingSystem : ComponentSystem
    {
        private Random _random;
        protected override void OnCreate()
        {
            _random = new Random();
            _random.InitState();
        }

        protected override void OnUpdate()
        {
            var config = World.TinyEnvironment().GetConfigData<GameConfig>();
            if (!EntityManager.Exists(World.TinyEnvironment().GetEntityByName("Food")) && config.FoodExist == false)
            {
                SceneService.LoadSceneAsync(config.FoodSceneReference);
                config.FoodExist = true;
                World.TinyEnvironment().SetConfigData(config);
            }
            var shouldSpawn = false;
            Entities.ForEach((Entity snakeEntity, ref SnakeHead snake, ref Translation snakeTransform) => {
                float3 snakeTrans = snakeTransform.Value;
                float3 foodTrans = new float3();

                Entities.ForEach((Entity foodEntity, ref FoodTag foodTag, ref Translation foodTransform) => {
                    foodTrans = foodTransform.Value;
                    if (math.distance(snakeTrans, foodTrans) < 1)
                    {
                        MoveFood(foodEntity);
                        shouldSpawn = true;
                    }
                });

                if (shouldSpawn)
                {
                    snake.GrowTail = true;
                }
            });
        }

        private void MoveFood(Entity food)
        {
            var translation = EntityManager.GetComponentData<Translation>(food);
            translation.Value = _random.NextInt3(new int3(-2, -5, 0), new int3(5, 2, 0));
            EntityManager.SetComponentData(food, translation);
        }
    }
}

