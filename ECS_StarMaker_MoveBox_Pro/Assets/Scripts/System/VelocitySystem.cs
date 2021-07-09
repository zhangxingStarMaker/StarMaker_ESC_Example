using Entitas;
using UnityEngine;

public class VelocitySystem : IExecuteSystem
{
    public void Execute()
    {
        var playerCollection =
            Contexts.sharedInstance.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Position,
                GameMatcher.Velocity));

        var velocity = Vector2.zero;
        
        if (Input.GetKey(KeyCode.W))
        {
            velocity.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity.y -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity.x += 1;
        }

        foreach (GameEntity player in playerCollection)
        {
            player.ReplaceVelocity(velocity);
        }
        
    }
    
}
