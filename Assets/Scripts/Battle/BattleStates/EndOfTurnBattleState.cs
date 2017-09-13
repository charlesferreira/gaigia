public class EndOfTurnBattleState : ISimpleState<BattleManager> {

    public void OnStateEnter(BattleManager bm) {
        bm.RemoveDeads();
        bm.SetState<PrepareNextTurnBattleState>();
    }

    public void OnStateExit(BattleManager bm) { }

    public void Update(BattleManager bm) { }

}