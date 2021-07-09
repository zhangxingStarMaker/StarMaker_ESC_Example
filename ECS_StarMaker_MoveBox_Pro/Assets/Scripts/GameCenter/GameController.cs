using System;
using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private Systems _systems;
    // Start is called before the first frame update
    void Start()
    {
        Contexts contexts = Contexts.sharedInstance;
        _systems = CreateSystems(contexts);
        GameEntity player = contexts.game.CreateEntity();
        player.isPlayer = true;
        player.AddPosition(Vector2.zero);
        player.AddVelocity(Vector2.zero);
        _systems.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }

    private void OnDestroy()
    {
        _systems.TearDown();
    }

    private Systems CreateSystems(Contexts contexts)
    {
        Systems systems = new Feature("Game").Add(new VelocitySystem()).Add(new PlayerSystem());
        return systems;
    }
}
