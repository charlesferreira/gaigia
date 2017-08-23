public class PrepareNextTurnBattleState : IBattleState {

    public void OnStateEnter(BattleManager bm) {
        bm.SelectNextCharacter();
        bm.MovementArea.SetUp(bm.Character);
        bm.SkillRange.SetUp(bm.Character);
        bm.SkillSetHUD.SetUp(bm.Character);
        bm.ActionSequence.SetUp(bm.Character);
        bm.SetState<SetSkillAndPositionBattleState>();
    }

    public void OnStateExit(BattleManager bm) { }

    public void Update(BattleManager bm) { }
}