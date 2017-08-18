public class SetUpBattleState : IBattleState {

    public void OnStateEnter(IBattleStateMachine fsm) {
        fsm.SetState<PrepareNextTurnBattleState>();
    }

    public void OnStateExit(IBattleStateMachine fsm) { }

    public void Update(IBattleStateMachine fsm) { }
}