public class SetUpBattleState : IBattleState {

    public void OnStateEnter(BattleManager bm) {
        bm.Reset();
    }

    public void OnStateExit(BattleManager bm) { }

    public void Update(BattleManager bm) { }
}