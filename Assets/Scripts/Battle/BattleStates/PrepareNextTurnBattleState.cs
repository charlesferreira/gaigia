public class PrepareNextTurnBattleState : IBattleState {

    public void OnStateEnter(IBattleStateMachine fsm) {
        MovementArea.Instance.SetUp(fsm.ActiveCharacter);
        SkillRange.Instance.SetUp(fsm.ActiveCharacter);
        SkillSetHUD.Instance.SetUp(fsm.ActiveCharacter);
        ActionSequence.Instance.SetUp(fsm.ActiveCharacter);
        fsm.SetState<SelectSkillAndPositionBattleState>();
    }

    public void OnStateExit(IBattleStateMachine fsm) { }

    public void Update(IBattleStateMachine fsm) { }
}