public class SelectTargetBattleState : ISimpleState<BattleManager> {

    public void OnStateEnter(BattleManager bm) {
        bm.ResetTarget();
        UpdateTarget(bm);
        bm.SkillTarget.SetActive(true);
    }

    public void OnStateExit(BattleManager bm) {
        bm.SkillTarget.SetActive(false);
    }

    public void Update(BattleManager bm) {
        if (PlayerInput.Cancel) {
            bm.SetState<SetSkillAndPositionBattleState>();
            return;
        }

        if (PlayerInput.RightShoulder) {
            bm.SelectNextTarget();
            UpdateTarget(bm);
        }

        if (PlayerInput.LeftShoulder) {
            bm.SelectPreviousTarget();
            UpdateTarget(bm);
        }

        if (PlayerInput.Confirm) {
            bm.SetState<CastSkillBattleState>();
        }
    }

    private void UpdateTarget(BattleManager bm) {
        bm.SkillTarget.SetTarget(bm.Target);
        CameraMan.Instance.SetTarget(bm.Target.transform);
    }
}