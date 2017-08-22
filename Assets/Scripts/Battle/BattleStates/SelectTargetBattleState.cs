public class SelectTargetBattleState : IBattleState {

    public void OnStateEnter(IBattleStateMachine bsm) {
        bsm.ResetTarget();
        UpdateTarget(bsm);
        SkillTarget.Instance.SetActive(true);
    }

    public void OnStateExit(IBattleStateMachine bsm) {
        SkillTarget.Instance.SetActive(false);
    }

    public void Update(IBattleStateMachine bsm) {
        if (PlayerInput.Cancel) {
            bsm.SetState<SetSkillAndPositionBattleState>();
            return;
        }

        if (PlayerInput.RightShoulder) { bsm.SelectNextTarget(); }
        if (PlayerInput.LeftShoulder)  { bsm.SelectPreviousTarget(); }
        if (PlayerInput.Confirm)       { bsm.SetState<CastSkillBattleState>(); }
    }

    private void UpdateTarget(IBattleStateMachine bsm) {
        SkillTarget.Instance.SetTarget(bsm.SelectedTarget);
        BattleCamera.Instance.SetTarget(bsm.SelectedTarget.transform);
    }
}