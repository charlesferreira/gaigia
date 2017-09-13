using UnityEngine;

public class PrepareNextTurnBattleState : ISimpleState<BattleManager> {

    public void OnStateEnter(BattleManager bm) {
        if (IsGameOver(bm)) {
            bm.SetState<GameOverBattleState>();
            return;
        }
        
        for (int i = 0; i < bm.Characters.Count; i++) {
            bm.SelectNextCharacter();
            if (bm.Character.IsAlive)
                break;
        }

        bm.MovementArea.SetUp(bm.Character);
        bm.SkillRange.SetUp(bm.Character);
        bm.SkillSetHUD.SetUp(bm.Character);
        bm.ActionSequence.SetUp(bm.Character);
        bm.SetState<SetSkillAndPositionBattleState>();
    }

    public void OnStateExit(BattleManager bm) { }

    public void Update(BattleManager bm) { }

    private bool IsGameOver(BattleManager bm) {
        return !bm.HasAlive(Team.Player) || !bm.HasAlive(Team.Computer);
    }
}