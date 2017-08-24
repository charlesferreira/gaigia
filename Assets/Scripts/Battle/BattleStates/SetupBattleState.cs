public class SetUpBattleState : ISimpleState<BattleManager> {

    public void OnStateEnter(BattleManager bm) {
        bm.ResetBattle();
    }

    public void OnStateExit(BattleManager bm) { }

    public void Update(BattleManager bm) { }
}