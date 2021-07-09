using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class PositionSystem : ReactiveSystem<GameEntity>
{
    public PositionSystem(Contexts context) : base(context.game)
    {
    }

    
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Velocity));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPosition && entity.hasVelocity;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity entity in entities)
        {
            var velocity = entity.velocity.Value;
            var newPosition = entity.position.Value + velocity * Time.deltaTime;
            entity.ReplacePosition(newPosition);
        }
    }
}
