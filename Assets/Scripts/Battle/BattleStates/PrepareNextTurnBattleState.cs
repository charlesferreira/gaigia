public class PrepareNextTurnBattleState : IBattleState {

    public void OnStateEnter(IBattleStateMachine bsm) {
        bsm.SelectNextCharacter();
        MovementArea.Instance.SetUp(bsm.ActiveCharacter);
        SkillRange.Instance.SetUp(bsm.ActiveCharacter);
        SkillSetHUD.Instance.SetUp(bsm.ActiveCharacter);
        ActionSequence.Instance.SetUp(bsm.ActiveCharacter);
        bsm.SetState<SelectSkillAndPositionBattleState>();
    }

    public void OnStateExit(IBattleStateMachine bsm) { }

    public void Update(IBattleStateMachine bsm) { }
}