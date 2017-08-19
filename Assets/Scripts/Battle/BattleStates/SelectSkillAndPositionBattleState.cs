using UnityEngine;

public class SelectSkillAndPositionBattleState : IBattleState {

    public void OnStateEnter(IBattleStateMachine bsm) {
        bsm.ActivateCurrentCharacter();
        BattleCamera.Instance.SetTarget(bsm.ActiveCharacter.transform);
    }

    public void OnStateExit(IBattleStateMachine bsm) {
        bsm.ActiveCharacter.Movement.Stop();
    }

    public void Update(IBattleStateMachine bsm) {
        bsm.UpdateTargets();
        SetPosition(bsm);
        SetCameraPan();
        SelectSkill(bsm);
    }

    private void SetPosition(IBattleStateMachine bsm) {
        var input = new Vector2(PlayerInput.LeftStickHorizontal, PlayerInput.LeftStickVertical);
        bsm.ActiveCharacter.Movement.Walk(input);
    }

    private void SetCameraPan() {
        var panX = PlayerInput.RightStickHorizontal;
        var panZ = PlayerInput.RightStickVertical;
        BattleCamera.Instance.Pan(panX, panZ);
    }

    private void SelectSkill(IBattleStateMachine bsm) {
        if (PlayerInput.RightShoulder) {
            bsm.ActiveCharacter.SelectNextSkill();
        }
        if (PlayerInput.LeftShoulder) {
            bsm.ActiveCharacter.SelectPreviousSkill();
        }
        if (PlayerInput.Confirm && bsm.Targets.Count > 0) {
            bsm.SetState<SelectTargetBattleState>();
        }
    }
}