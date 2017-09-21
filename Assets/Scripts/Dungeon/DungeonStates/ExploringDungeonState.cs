using UnityEngine;

public class ExploringDungeonState : ISimpleState<DungeonManager> {

    public void OnStateEnter(DungeonManager dm) { }

    public void OnStateExit(DungeonManager dm) { }

    public void Update(DungeonManager dm) {
        var input = new Vector2(PlayerInput.LeftStickHorizontal, PlayerInput.LeftStickVertical);
        dm.Character.Movement.Walk(input);
    }
}