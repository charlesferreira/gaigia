public class SelectTargetBattleState : IBattleState {

    public void OnStateEnter(IBattleStateMachine fsm) { }

    public void OnStateExit(IBattleStateMachine battleManager) { }

    public void Update(IBattleStateMachine fsm) {
        if (PlayerInput.Confirm) {
            fsm.SelectNextCharacter();
            fsm.SetState<SelectSkillAndPositionBattleState>();
        }

        FocusOnTarget();
    }

    public void FixedUpdate(IBattleStateMachine fsm) { }
}