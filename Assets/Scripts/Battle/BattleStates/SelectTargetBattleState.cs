public class SelectTargetBattleState : IBattleState {

    private int targetIndex;

    public void OnStateEnter(IBattleStateMachine bsm) {
        targetIndex = 0;
        UpdateTarget(bsm);
        SkillTarget.Instance.SetActive(true);
    }

    public void OnStateExit(IBattleStateMachine bsm) {
        SkillTarget.Instance.SetActive(false);
    }

    public void Update(IBattleStateMachine bsm) {
        if (PlayerInput.Cancel) {
            bsm.SetState<SelectSkillAndPositionBattleState>();
            return;
        }

        if (PlayerInput.RightShoulder) { SelectNextTarget(bsm); }
        if (PlayerInput.LeftShoulder)  { SelectPreviousTarget(bsm); }
        if (PlayerInput.Confirm) {
            bsm.SelectNextCharacter();
            bsm.SetState<CastSkillBattleState>();
        }
    }

    private void SelectNextTarget(IBattleStateMachine bsm) {
        targetIndex += 1;
        targetIndex %= bsm.Targets.Count;
        UpdateTarget(bsm);
    }

    private void SelectPreviousTarget(IBattleStateMachine bsm) {
        targetIndex += bsm.Targets.Count - 1;
        targetIndex %= bsm.Targets.Count;
        UpdateTarget(bsm);
    }

    private void UpdateTarget(IBattleStateMachine bsm) {
        var target = bsm.Targets[targetIndex];
        bsm.ActiveCharacter.Skill.Target = target;
        SkillTarget.Instance.SetTarget(target);
        BattleCamera.Instance.SetTarget(target.transform);
    }
}