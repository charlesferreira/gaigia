public class GameOverBattleState : ISimpleState<BattleManager> {

    public void OnStateEnter(BattleManager bm) {
        bm.ShowGameOverScreen();
    }

    public void OnStateExit(BattleManager bm) { }

    public void Update(BattleManager bm) { }

}