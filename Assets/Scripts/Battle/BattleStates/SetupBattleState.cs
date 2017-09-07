public class SetUpBattleState : ISimpleState<BattleManager> {

    public void OnStateEnter(BattleManager bm) {
        bm.ResetBattle();
        bm.SetState<PrepareNextTurnBattleState>();
    }

    public void OnStateExit(BattleManager bm) { }

    public void Update(BattleManager bm) { }
}