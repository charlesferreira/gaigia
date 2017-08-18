using UnityEngine;

public class SelectSkillAndPositionBattleState : IBattleState {

    SkillSet skillSet;
    CharacterMovement characterMovement;

    public void OnStateEnter(IBattleStateMachine fsm) {
        fsm.ActivateCurrentCharacter();
        skillSet = fsm.ActiveCharacter.GetComponent<SkillSet>();
        characterMovement = fsm.ActiveCharacter.GetComponent<CharacterMovement>();
        BattleCamera.Instance.SetTarget(fsm.ActiveCharacter.transform);
    }

    public void OnStateExit(IBattleStateMachine fsm) {
        characterMovement.Stop();
    }

    public void Update(IBattleStateMachine fsm) {
        fsm.UpdateTargets();
        SetPosition();
        SetCameraPan();
        SelectSkill(fsm);
    }

    private void SelectSkill(IBattleStateMachine fsm) {
        if (PlayerInput.RightShoulder) { skillSet.SelectNextSkill(); }
        if (PlayerInput.LeftShoulder)  { skillSet.SelectPreviousSkill(); }
        if (PlayerInput.Confirm && fsm.Targets.Count > 0) {
            fsm.SetState<SelectTargetBattleState>();
        }
    }

    private void SetPosition() {
        var input = new Vector2(PlayerInput.LeftStickHorizontal, PlayerInput.LeftStickVertical);
        characterMovement.Walk(input);
    }

    private void SetCameraPan() {
        var panX = PlayerInput.RightStickHorizontal;
        var panZ = PlayerInput.RightStickVertical;
        BattleCamera.Instance.Pan(panX, panZ);
    }
}