public class SetUpBattleState : IBattleState {

    public void OnStateEnter(IBattleStateMachine fsm) {
        fsm.SetState<SelectSkillAndPositionBattleState>();
    }

    public void OnStateExit(IBattleStateMachine fsm) { }

    public void Update(IBattleStateMachine fsm) { }

    public void FixedUpdate(IBattleStateMachine fsm) { }
}