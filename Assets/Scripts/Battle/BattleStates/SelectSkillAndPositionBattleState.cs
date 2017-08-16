using UnityEngine;

public class SelectSkillAndPositionBattleState : IBattleState {

    CharacterMovement characterMovement;
    SkillSet skillSet;

    public void OnStateEnter(IBattleStateMachine fsm) {
        characterMovement = fsm.ActiveCharacter.GetComponent<CharacterMovement>();
        skillSet = fsm.ActiveCharacter.GetComponent<SkillSet>();
    }

    public void OnStateExit(IBattleStateMachine fsm) {
        characterMovement.Stop();
    }

    public void Update(IBattleStateMachine fsm) {
        if (PlayerInput.RightShoulder) {
            skillSet.SelectNextSkill();
        }

        if (PlayerInput.LeftShoulder) {
            skillSet.SelectPreviousSkill();
        }

        if (PlayerInput.Confirm) {
            fsm.SetState<SelectTargetBattleState>();
        }

        BattleCamera.Instance.Pan(PlayerInput.RightStickHorizontal, PlayerInput.RightStickVertical);
    }

    public void FixedUpdate(IBattleStateMachine fsm) {
        var input = new Vector2(PlayerInput.LeftStickHorizontal, PlayerInput.LeftStickVertical);
        if (input != Vector2.zero)
            characterMovement.Walk(input);
        else
            characterMovement.Stop();
    }

}