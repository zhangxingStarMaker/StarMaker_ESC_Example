using Entitas;
using UnityEngine;

public class PlayerSystem : IExecuteSystem
{
    public void Execute()
    {
        var playerCollection =
            Contexts.sharedInstance.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Position,
                GameMatcher.Velocity));
        foreach (GameEntity entity in playerCollection)
        {
            var velocity = entity.velocity.Value;
            var newPosition = entity.position.Value + velocity * Time.deltaTime;
            entity.ReplacePosition(newPosition);
        }
    }
}
